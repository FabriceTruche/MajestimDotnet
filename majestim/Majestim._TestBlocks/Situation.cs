using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using Common.Blocks.Impl;
using Common.Blocks.Interface;
using log4net;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Newtonsoft.Json;

namespace Majestim._TestBlocks
{
    public class Situation
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly IContratService _contratService;
        private readonly ISituationLocataireService _situService;

        public Situation(
            IContratService contratService,
            ISituationLocataireService situService)
        {
            this._contratService = contratService;
            this._situService = situService;
        }

        public void Run()
        {
            IEnumerable<ContratDto> contrats = this._contratService.ContratsDtoActif();
            OneMany<OperationDto, EcritureDto> situ = this._situService.SelectLigneSituation(contrats.Select(x => x.ID).ToList());
            SituationVisitor visitor = new SituationVisitor();

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(situ, Formatting.Indented);
            File.WriteAllText("export.js", json);

            this._situService.Visit(situ,visitor);

            log.Info("=> fini");

            string res = visitor.MainBlock.Eval("class","colspan","Title","Col");

            File.WriteAllText("tv.js", Resource1.tvJs, Encoding.UTF8);
            File.WriteAllText("tv.css", Resource1.tvCss, Encoding.UTF8);
            File.WriteAllText("test.html", res, Encoding.UTF8);
        }
    }
}