using System;
using System.Windows.Forms;
using AutoMapper;
using log4net.Config;
using Majestim.DTO.DTO;
using Majestim._TestObjectListView.Example;
using Majestim._TestObjectListView.TestOLV;

namespace Majestim._TestObjectListView
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            XmlConfigurator.Configure();
            Form3 f = new Form3();

            Application.Run(f);
            return;


            //MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<INDIVIDU, Individu>());
            //IMapper mapper = config.CreateMapper();

            //INDIVIDU indi = new INDIVIDU
            //{
            //    NOM = "Hello",
            //    ID = 123
            //};
            //Individu ib = mapper.Map<Individu>(indi);

            //new PdfTest().DrawArray();
            new PdfDDL().Run();
            return;


        }
    }
}
