using System;

namespace Majestim.BO.OperationGestion.AppelLoyer
{
    public class LigneAppelStatus
    {
        public DateTime Periode { get; set; }
        public int Contrat_ID { get; set; }
        public bool DejaAppele { get; set; }
    }
}