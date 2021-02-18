using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Majestim._TestObjectListView.TestOLV.Editor
{
    public static class CustomEditor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static Dictionary<Type, Type> _mapEditor = new Dictionary<Type, Type>();

        /// <summary>
        /// enregistre un editro pour un modèle donné
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TEditor"></typeparam>
        public static void Register<TModel, TEditor>()
        {
            if (_mapEditor.ContainsKey(typeof(TModel)))
                return;

            _mapEditor.Add(typeof(TModel), typeof(TEditor));
        }

        /// <summary>
        /// retorune un editor pour un model donné
        /// </summary>
        /// <returns></returns>
        public static Control GetEditor(Type model)
        {
            if (!_mapEditor.ContainsKey(model))
                return null;

            if (!(Activator.CreateInstance(_mapEditor[model]) is Control control))
                return null;

            return control;
        }
    }
}