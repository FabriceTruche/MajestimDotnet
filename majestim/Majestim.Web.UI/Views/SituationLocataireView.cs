using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Web.UI.Interface;

namespace Majestim.Web.UI.Views
{
    public class SituationLocataireView : ISituationLocataireWebView
    {
        public string GetView(OneMany<OperationDto, EcritureDto> data, ChoixNbMois nbMois)
        {
            string res = nbMois.Libelle + "<br>";

            foreach (KeyValuePair<OperationDto, IList<EcritureDto>> pair in data)
            {
                res +=  pair.Key.Contrat_ID + " => " + pair.Key.Contrat + "<br>";
                foreach (EcritureDto ecritureDto in pair.Value)
                {
                    res += ecritureDto.Compte + " - " + ecritureDto.Libelle + " - " + ecritureDto.Debit + " - " +
                           ecritureDto.Credit + "<br>";
                }

            }

            return res;
        }

        public IList<object> GetView2(OneMany<OperationDto, EcritureDto> data)
        {
            List<object> res = new List<object>();

            foreach (KeyValuePair<OperationDto, IList<EcritureDto>> pair in data)
            {
                List<object> ecritures = new List<object>();

                foreach (EcritureDto ecritureDto in pair.Value)
                {
                    ecritures.Add(new
                    {
                        id = ecritureDto.ID,
                        libelle = ecritureDto.Libelle,
                        debit = ecritureDto.Debit,
                        credit = ecritureDto.Credit,
                    });
                }
                res.Add(new
                {
                    contrat = pair.Key.Contrat,
                    dateOpe = pair.Key.DateOperation,
                    commentaire = pair.Key.Commentaire,
                    ecritures = ecritures
                });
            }

            return res;
        }

    }
}