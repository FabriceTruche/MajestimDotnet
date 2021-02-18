using System.Collections.Generic;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using NUnit.Framework;

namespace Majestim._Console
{
    [TestFixture]
    public class UnitOfWorkTest : BaseTest
    {
        [Test]
        public void ListeOperationsTest()
        {
            IRepository<OperationDto> repo = this.Uow.Repository<OperationDto>();
            IEnumerable<OperationDto> res = repo.GetAll();

            this.Dump(new { result= res});
        }

        [Test]
        public void Test2()
        {
            
        }

        [Test]
        public void Test3()
        {
            
        }

        [Test]
        public void Test4()
        {
            
        }
    }
}
