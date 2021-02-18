using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.Rapport.SituationLocataire.Compta
{
    public class SituationLocataireService : ISituationLocataireService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;
        private readonly IPeriodeService _periodeService;

        public SituationLocataireService(
            IContext context,
            IPeriodeService periodeService)
        {
            this._context = context;
            this._periodeService = periodeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrats"></param>
        /// <returns></returns>
        public OneMany<OperationDto, EcritureDto> SelectLigneSituation(IList<int> contrats)
        {
            string query = @"
select 
    o.id,                
    c.NOM Contrat, 
    o.periode Periode, 
    o.Contrat_ID,
    o.dateOperation DateOperation, 
    tope.code typeOperation,
    e.id Id, 
    e.libelle Libelle, 
    cp.Numero Compte,
    round(e.debit, 2) Debit, 
    round(e.credit, 2) Credit
from ECRITURE e, OPERATION o, CONTRAT c, TYPEOPERATION tope, COMPTE cp
where e.OPERATION_ID = o.ID
and o.CONTRAT_ID = c.ID
and e.COMPTE_ID = (select id from COMPTE where NUMERO = '411000')
and tope.ID = o.typeOperation_ID
and cp.ID = e.Compte_ID
and ( o.CONTRAT_ID in @contrats or @allContrats )
order by 2 asc,3 asc
";
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                OneMany<OperationDto, EcritureDto> res = uow.QueryOneMany<OperationDto,EcritureDto>(
                    query,
                    new
                    {
                        contrats = contrats.ToArray(),
                        allContrats = contrats.Count==0
                    }
                );

                return res;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// converti les data pour le report
        /// </summary>
        /// <param name="nbMois"></param>
        /// <param name="lignes"></param>
        /// <param name="visitor"></param>
        /// <returns></returns>
        //public IList<LigneSituationRo> ConvertToReport(
        //    ChoixNbMois nbMois,
        //    OneMany<OperationDto, EcritureDto> lignes,
        //    ISituationLocataireVisitor visitor)
        public void Visit(
            OneMany<OperationDto, EcritureDto> lignes,
            ISituationLocataireVisitor visitor)
        {
            KeyValuePair<OperationDto,IList<EcritureDto>>[] rows = lignes.ToArray();

            if (rows.Any())
            {
                int i = 0;

                while (i < rows.Length)
                {
                    string contrat = rows[i].Key.Contrat;
                    visitor.OnBeginContrat(rows[i]);

                    while (i < rows.Length && rows[i].Key.Contrat == contrat)
                    {
                        DateTime? periode = rows[i].Key.Periode;
                        visitor.OnBeginContratPeriode(rows[i]);

                        while (i < rows.Length && rows[i].Key.Contrat == contrat &&
                               this._periodeService.SamePeriode(periode, rows[i].Key.Periode))
                        {
                            visitor.OnRow(rows[i]);
                            i++;
                        }
                        visitor.OnEndContratPeriode(contrat, periode);
                    }
                    visitor.OnEndContrat(contrat);
                }
            }

            //return visitor.Report;
        }
    }
}





//OneManyBuilder<OperationDto, EcritureDto> builder =
//    new OneManyBuilder<OperationDto, EcritureDto>(this._context);

