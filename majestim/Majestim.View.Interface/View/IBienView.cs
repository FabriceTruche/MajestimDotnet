using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Majestim.BO;
using Majestim.BO.OperationBase.Patrimoine;

namespace Majestim.View.Interface.View
{
    public interface IBienView
    {
        void ShowBiens(IEnumerable<Bien> biens);

        event EventHandler OnBiensDisplayed;
    }
}