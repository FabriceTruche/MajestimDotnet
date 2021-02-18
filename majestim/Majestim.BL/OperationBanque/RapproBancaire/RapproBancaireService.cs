using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Dapper;
using Majestim.BL.Interface.OperationBanque.RapproBancaire;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Unity;
using Unity.Resolution;

namespace Majestim.BL.OperationBanque.RapproBancaire
{
    public class RapproBancaireService : IRapproBancaireService
    {
        private readonly IContext _context;

        public RapproBancaireService(
            IContext context)
        {
            this._context = context;
        }

        public IList<LigneBanque> ImportData(string data)
        {
            // on assume en première implémentation le formalisme CA en Version 2
            /* row 1 : date operation
             * row 2 : libellé 1
             * rom 3 : libellé 2
             * row 4 : montant
             * ligne vide => on passe */

            List<LigneBanque> list = new List<LigneBanque>();
            string[] values = data.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int index = 1;
            int line = 1;
            LigneBanque lb = null;
            string value = "";

            try
            {
                foreach (string v in values)
                {
                    value = v.Replace(" "," ");
                    switch (index)
                    {
                        case 1: // date
                            lb = new LigneBanque();
                            lb.Id = list.Count+1;

                            if (!DateTime.TryParseExact(value, "dd-MMM", new CultureInfo("fr-FR"),DateTimeStyles.AllowWhiteSpaces, out DateTime d) &&
                                !DateTime.TryParseExact(value + ".", "dd-MMM", new CultureInfo("fr-FR"),DateTimeStyles.AllowWhiteSpaces, out d))
                                throw new Exception($"Date invalide : {value}");

                            lb.Date = d;
                            index++;
                            break;

                        case 2: // libelle 1
                            lb.Libelle = value;
                            index++;
                            break;

                        case 3: // libelle 2
                            lb.Libelle += " - " + value;
                            index++;
                            break;

                        case 4: // montant
                            lb.Montant = double.Parse(value.Replace(" ", ""), NumberStyles.Currency);
                            list.Add(lb);
                            // " "
                            index = 1;
                            break;
                    }
                    line++;
                }
            }
            catch (Exception e)
            {
                string err = $"Erreur d'import à la ligne {line}";
                err += Environment.NewLine + $"valeur en cours d'analyse : {value} index {index}";

                MessageBox.Show(err, "Erreur d'import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                list.Clear();
            }

            return list;
        }

        /// <summary>
        /// analyser les lignes de banques
        /// </summary>
        /// <param name="lignesBanque"></param>
        /// <returns></returns>
        public IList<LigneRapproCompta> AnalyzeLignesBanque(IList<LigneBanque> lignesBanque)
        {
            List<LigneRapproCompta> rapproCompta = new List<LigneRapproCompta>();
            List<IAnalyzerRappro> rapproRegles = new List<IAnalyzerRappro>();

            // 1. récupérer les règles de rapprochement à prendre en compte
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<RegleRapproDto> regles = null;

                regles = uow.Repository<RegleRapproDto>().GetAll("actif=1");

                // 1.1. récupérer le pilote de chaque règle
                foreach (RegleRapproDto regleRapproDto in regles)
                {
                    ParameterOverride pRegle = new ParameterOverride(typeof(RegleRapproDto), regleRapproDto);
                    ParameterOverride pContext  = new ParameterOverride(typeof(IContext), this._context);
                    IContratService pContratService = this._context.Container.Resolve<IContratService>();
                    ParameterOverride pContrat = new ParameterOverride(typeof(IContratService), pContratService);

                    rapproRegles.Add(this._context.Container.Resolve<IAnalyzerRappro>(regleRapproDto.Nom, pRegle, pContext, pContrat));
                }
            }

            // 2. pour chaque ligne de banque, vérifier si la ligne comptable peut en être déduite
            foreach (LigneBanque lb in lignesBanque)
            {
                foreach (IAnalyzerRappro regle in rapproRegles)
                {
                    IList<LigneRapproCompta> rapprosCompta = regle.AnalyzeLigneBanque(lb);

                    if (rapprosCompta != null)
                    {
                        // 3. ajouter les lignes d'écritures comptables déduites
                        rapproCompta.AddRange(rapprosCompta);

                        // on ne traite pas les règles suivantes
                        break;
                    }
                }
            }

            return rapproCompta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lignesBanque"></param>
        /// <returns></returns>
        public IList<LigneBanqueRo> Convert(IList<LigneBanque> lignesBanque)
        {
            List<LigneBanqueRo> rows = new List<LigneBanqueRo>();

            foreach (LigneBanque ligneBanque in lignesBanque)
                rows.Add(new LigneBanqueRo(ligneBanque));

            return rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lignesCompta"></param>
        /// <returns></returns>
        public IList<LigneRapproComptaRo> Convert(IList<LigneRapproCompta> lignesCompta)
        {
            List<LigneRapproComptaRo> rows = new List<LigneRapproComptaRo>();

            foreach (LigneRapproCompta lrc in lignesCompta)
                rows.Add(new LigneRapproComptaRo(lrc));

            return rows;
        }
    }
}