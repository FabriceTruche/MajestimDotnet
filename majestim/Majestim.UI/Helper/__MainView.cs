//using System;
//using System.Globalization;
//using System.Reflection;
//using System.Windows.Forms;
//using Majestim.Interface.View;
//using Majestim.Presenters;
//using Majestim.Views.Forms;

//namespace Majestim.Views.Views
//{
//    public class MainView : IMainView
//    {
//        private readonly Control _bienView;
//        private readonly Control _tiersView;
//        private readonly Control _contratView;

//        public MainView(
//            Control bienView,
//            Control tiersView,
//            Control contratView)
//        {
//            _bienView = bienView;
//            _tiersView = tiersView;
//            _contratView = contratView;
//        }


//        public void ShowTiersView()
//        {
//            throw new NotImplementedException();
//        }

//        public void ShowBienView()
//        {
//            throw new NotImplementedException();
//        }

//        public void ShowContratView()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        void IMainView.Start()
//        {
//            _presenter.Start();
//        }

//        public event EventHandler Load;

//        /// <summary>
//        /// 
//        /// </summary>
//        void IMainView.OpenMainWindow()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new MainForm(this));
//        }

        

//    }
//}





////void IMainView.OpenView(Panel panel, Button button)
////{
////string controlName = button.Name.Substring(6);
////Control newControl = this.CreateControl(controlName);

////panel.Controls.Clear();

////if (newControl != null)
////{
////    newControl.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
////    newControl.Size = panel.Size;
////    panel.Controls.Add(newControl);
////}
////}

/////// <summary>
/////// 
/////// </summary>
/////// <param name="controlName"></param>
/////// <returns></returns>
////private Control CreateControl(string controlName)
////{
////Assembly ai = Assembly.GetExecutingAssembly();

////Object view = ai.CreateInstance($"Majestim.Views.Views.{controlName}View", true,
////    BindingFlags.CreateInstance, null, null, CultureInfo.CurrentCulture, null);

////Object t = ai.CreateInstance($"Majestim.Views.Controls.{controlName}Control", true,
////    BindingFlags.CreateInstance, null, new[] { view }, CultureInfo.CurrentCulture, null);

////Type[] ts = ai.GetTypes();

////    return t as Control;
////}
