using System;
using System.Collections.Generic;
using System.Linq;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBase.Compta
{
    public class ComptesService : IComptesService
    {
        private readonly IContext _context;
        private List<CompteDto> _comptes = null;

        public ComptesService(IContext context)
        {
            this._context = context;
        }

        private void CheckInitComptes()
        {
            if (this._comptes == null)
                using (IUnitOfWork uow = new UnitOfWork(this._context))
                    this._comptes = uow.Repository<CompteDto>().GetAll().ToList();
        }

        CompteDto IComptesService.CompteFromId(int id)
        {
            this.CheckInitComptes();
            return this._comptes.SingleOrDefault(x => x.ID == id);
        }

        CompteDto IComptesService.CompteFromNom(string nom)
        {
            this.CheckInitComptes();
            return this._comptes.SingleOrDefault(x => x.Numero.Equals(nom, StringComparison.InvariantCultureIgnoreCase));
        }

        int? IComptesService.IdFromNom(string nom)
        {
            this.CheckInitComptes();
            return this._comptes.SingleOrDefault(x => x.Numero.Equals(nom, StringComparison.InvariantCultureIgnoreCase))?.ID;
        }

        string IComptesService.NomFromId(int compteId)
        {
            this.CheckInitComptes();
            return this._comptes.SingleOrDefault(x => x.ID == compteId)?.Numero;
        }
    }
}