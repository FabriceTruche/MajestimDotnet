using Majestim.BO.OperationBase.Compta;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.Web.UI.Interface
{
    public interface ISituationLocataireWebView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nbMois"></param>
        /// <returns></returns>
        string GetView(OneMany<OperationDto, EcritureDto> data, ChoixNbMois nbMois);
    }
}