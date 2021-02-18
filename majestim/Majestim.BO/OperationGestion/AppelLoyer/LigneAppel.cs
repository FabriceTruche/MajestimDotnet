using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;
using Majestim.DTO.Enum;

namespace Majestim.BO.OperationGestion.AppelLoyer
{
    public class LigneAppel
    {
        public LigneAppel()
        {
            this.AppelLoyerDetail = new List<LigneAppelDetail>();
        }

        public DateTime Periode { get; set; }
        public ContratRo Bail { get; set; }
        public TypeAppel TypeAppel { get; set; }
        public bool DejaAppele { get; set; }
        public List<LigneAppelDetail> AppelLoyerDetail { get; }
    }
}