using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBase.Patrimoine
{
    public class BienService : IBienService
    {
        private readonly IContext _context;
        //private readonly IRepository<BienDto> _repoBien;

        public BienService(
            //IRepository<BienDto> repoBien
            IContext context
            )
        {
            this._context = context;
            //this._repoBien = repoBien;
        }

        public IEnumerable<Bien> GetBiens()
        {
            IEnumerable<Bien> res = null;

            return res;
        }
    }
}