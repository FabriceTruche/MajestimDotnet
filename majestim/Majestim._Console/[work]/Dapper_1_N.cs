//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using Dapper;
//using log4net;
//using log4net.Config;
//using Majestim.BO.OperationBase.Compta;
//using Majestim.DTO.DTO;
//using MySql.Data.MySqlClient;

//namespace Majestim._Console
//{
//    public class Dapper_1_N
//    {
//            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        public void Main()
//        {

//            XmlConfigurator.Configure();

//            using (MySqlConnection mysqlCnx = new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim"))
//            {
//                string query = @"
//select 
//	o.*, c.nom Contrat, e.* 
//from OPERATION o
//inner join ECRITURE e on o.ID = e.Operation_ID
//inner join CONTRAT c on c.id = o.Contrat_ID 
//";
//                MasterSlave<OperationDto,EcritureDto> ms = new MasterSlave<OperationDto, EcritureDto>(mysqlCnx);

//                ms.Query(query);

//                foreach (KeyValuePair<OperationDto, List<EcritureDto>> item in ms)
//                {
//                    log.Info($"master={item.Key.Contrat} {item.Key.Periode} {item.Key.Contrat_ID}");
//                    foreach (EcritureDto dto in item.Value)
//                    {
//                        log.Info($"    slave={dto.ID} {dto.Operation_ID} {dto.Compte_ID} {dto.Debit} {dto.Credit}");
//                    }
//                }

//                //List<Operation> result = new List<Operation>();
//                //List<Operation> res = mysqlCnx.Query<OperationDto, EcritureDto, Operation>(
//                //    query,
//                //    (ope, ecr) => this.MergeResult(result, ope, ecr)).ToList();

//            }
//        }

//        //private Operation MergeResult(List<Operation> result, OperationDto ope, EcritureDto ecr)
//        //{
//        //    Operation currentOpe = result.FirstOrDefault(x => x.Id == ope.ID);

//        //    if (currentOpe == null)
//        //    {
//        //        currentOpe = new Operation
//        //        {
//        //            Id = ope.ID,
//        //            DateOperation = ope.DateOperation,
//        //            NumOperation = ope.NumOperation,
//        //            Periode = ope.Periode,
//        //        };

//        //        result.Add(currentOpe);
//        //    }

//        //    currentOpe.Ecritures.Add(new Ecriture
//        //    {
//        //        Libelle = ecr.Libelle,
//        //        Debit = ecr.Debit,
//        //        Credit = ecr.Credit
//        //    });

//        //    return null;
//        //}
//    }
//}