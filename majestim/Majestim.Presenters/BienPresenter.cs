using System;
using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Patrimoine;
using Majestim.BO;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class BienPresenter
    {
        private readonly IBienView _bienView;
        private readonly IBienService _bienService;

        public BienPresenter(IBienView bienView,  IBienService bienService)
        {
            this._bienView = bienView;
            this._bienService = bienService;

            this._bienView.OnBiensDisplayed += this.BienViewOnOnShow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void BienViewOnOnShow(object sender, EventArgs eventArgs)
        {
            IEnumerable<Bien> res = this._bienService.GetBiens();

            this._bienView.ShowBiens(res);
        }
    }
}