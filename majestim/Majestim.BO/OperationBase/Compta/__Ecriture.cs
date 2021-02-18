//using Majestim.DTO.DTO;
//using Majestim.Interface;

//namespace Majestim.BO.OperationBase.Compta
//{
//    public class Ecriture : ISimpleMapper<EcritureDto>
//    {
//        public int Id { get; set; }
//        public int NumEcr { get; set; }
//        public string Compte { get; set; }
//        public string Libelle { get; set; }
//        public double? Debit { get; set; }
//        public double? Credit { get; set; }


//        public EcritureDto Dto =>
//            new EcritureDto
//            {
//                //COMPTE_ID = this.Compte,
//                //CREDIT = this.Credit,
//                //DEBIT = this.Debit,
//                Libelle = this.Libelle,
//            };

//        public static implicit operator Ecriture(EcritureDto ecr) =>
//            new Ecriture
//            {
//                Credit = ecr.Credit,
//                Debit = ecr.Debit,
//                Libelle = ecr.Libelle
//            };
//    }
//}