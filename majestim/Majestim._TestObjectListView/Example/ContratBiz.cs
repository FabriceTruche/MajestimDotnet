using System;
using System.Reflection;
using BrightIdeasSoftware;
using log4net;
using MySql.Data.MySqlClient;

namespace Majestim._TestObjectListView.Example
{
    public class ContratBiz
    {
        public int id { get; set; }
        public string nom { get; set; }

        [OLVColumn("Date entrée locataire")]
        public DateTime date_entree { get; set; }

        //[OLVColumn("Type de contrat")]
        //[Write(false)]
//        public TypeContrat type_contrat { get; set; }
    }
}