using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Majestim._TestObjectListView
{
    public class tiers_view
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string code_tiers { get; set; }
    }



    public class MyType
    {
        private Func<string> _func;

        public MyType(Func<string> func)
        {
            _func = func;
        }


        [OLVColumn("Nom de l'individu", DisplayIndex = 2, Width = 175, TextAlign = HorizontalAlignment.Left)]
        public string nom { get; set; }

        [OLVColumn("Preno de l'individu", DisplayIndex = 2, Width = 175, TextAlign = HorizontalAlignment.Left)]
        public string prenom { get; set; }

        [OLVColumn("Nom calculé", DisplayIndex = 2, Width = 175, TextAlign = HorizontalAlignment.Left)]
        public string nom_calculated => this._func();

        /// <summary>
        /// fsdfsdf sdf sd
        ///  sdf 
        /// </summary>
        public string mail { get; set; }

        //[OLVColumn("Champ calculé", DisplayIndex = 10, Width = 200, TextAlign = HorizontalAlignment.Left)]
        //public string NomMail => nom + " - " + mail;

   }

    public class TypeChoix
    {
        public string str { get; set; }
        public bool boolean { get; set; }
        public string str2 => str + " //";
        public List<TypeChoix> items { get; set; }
    }
}