using System;
using System.Collections.Generic;
using System.Linq;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.Rapport.CompteLocataire.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.Rapport.CompteLocataire.Compta
{
    public class CompteLocataireService : ICompteLocataireService
    {
        private readonly IContext _context;
        private readonly IPeriodeService _periodeService;

        public CompteLocataireService(
            IContext context,
            IPeriodeService periodeService)
        {
            this._context = context;
            this._periodeService = periodeService;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periodeDebut"></param>
        /// <param name="periodeFin"></param>
        /// <param name="comptes"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public OneMany<OperationDto, EcritureDto> SelectLigneEcritures(
            ContratRo contrat,
            ChoixPeriode periodeDebut,
            ChoixPeriode periodeFin,
            IEnumerable<string> comptes,
            IEnumerable<string> operations)
        {
            string query = @"
select 
    o.Id,
	tyop.CODE TypeOperation,
	c.NOM Contrat, 
	o.periode Periode, 
	o.dateOperation DateOperation, 
	e.id Id, 
	e.libelle Libelle, 
	cp.NUMERO Compte, 
	round(e.debit, 2) Debit, 
	round(e.credit, 2) Credit
from ECRITURE e, OPERATION o, CONTRAT c, COMPTE cp, TYPEOPERATION tyop
where e.OPERATION_ID = o.ID
and tyop.ID = o.TYPEOPERATION_ID
and cp.ID = e.COMPTE_ID
and tyop.CODE in @operations
and o.CONTRAT_ID = c.ID
and e.COMPTE_ID in (select id from COMPTE where NUMERO in @comptes)
and o.CONTRAT_ID = @contratId
$periodeDebut 
$periodeFin 
order by contrat,periode,dateOperation,TypeOperation,compte
";

            query = query.Replace("$periodeDebut", periodeDebut.Periode != DateTime.MinValue ? "and o.periode >= @periodeDebut" : "");
            query = query.Replace("$periodeFin", periodeFin.Periode != DateTime.MinValue ? "and o.periode <= @periodeFin" : "");



            //OneManyBuilder<OperationDto, EcritureDto> builder = new OneManyBuilder<OperationDto, EcritureDto>(this._context);

            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                OneMany<OperationDto, EcritureDto> res = uow.QueryOneMany<OperationDto,EcritureDto>(
                    query,
                    new
                    {
                        contratId = contrat.Id,
                        operations,
                        comptes,
                        periodeDebut = periodeDebut.Periode,
                        periodeFin = periodeFin.Periode,
                    });

                return res;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="lignes"></param>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public IEnumerable<LigneComptesLocataireRo> ConvertToReport(OneMany<OperationDto, EcritureDto> lignes,ICompteLocataireVisitor visitor)
        {
            KeyValuePair<OperationDto, IList<EcritureDto>>[] rows = lignes.ToArray();

            if (rows.Any())
            {
                int i = 0;

                visitor.OnBegin();

                while (i < rows.Length)
                {
                    DateTime? periode = rows[i].Key.Periode;
                    visitor.OnBeginPeriode(rows[i]);

                    while (i < rows.Length &&
                           this._periodeService.SamePeriode(periode, rows[i].Key.Periode))
                    {
                        DateTime date = rows[i].Key.DateOperation;
                        visitor.OnBeginPeriodeDate(rows[i], date);

                        while (i < rows.Length &&
                               this._periodeService.SamePeriode(periode, rows[i].Key.Periode) &&
                               date == rows[i].Key.DateOperation)
                        {
                            visitor.OnRow(rows[i]);
                            i++;
                        }
                        visitor.OnEndPeriodeDate(date);
                    }
                    visitor.OnEndPeriode(periode);
                }

                visitor.OnEnd();
            }
            return visitor.Report;
        }

    }
}

