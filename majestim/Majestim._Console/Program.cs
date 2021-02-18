using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using Majestim.Application.Conf;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Unity;

namespace Majestim._Console
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void __Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(CopyToClipboard));
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static void CopyToClipboard()
        {
            IDataObject clip = Clipboard.GetDataObject();
            if (clip.GetDataPresent(DataFormats.Text))
            {
                Console.WriteLine("" + clip.GetData(DataFormats.Text));
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            IDataObject clip = Clipboard.GetDataObject();
            if (clip.GetDataPresent(DataFormats.Text))
            {
                Console.WriteLine("" + clip.GetData(DataFormats.Text));
            }
        }

        static void Test1(IUnitOfWork uow)
        {
            IRepository<OperationDto> repo = uow.Repository<OperationDto>();
            IEnumerable<OperationDto> res = repo.GetAll();
        }

        static void Test2(IUnitOfWork uow)
        {
            IRepository<AdresseDto> repoAdr = uow.Repository<AdresseDto>();
            AdresseDto adr = new AdresseDto
            {
                Adr1 = "Hello",
                Adr2 = "World",
                Ville = "Montélimar"
            };

            log.Info($"id before={adr.ID}");
            repoAdr.Insert(adr);
            log.Info($"id after={adr.ID}");

            uow.Rollback();
        }

        static void Main1(string[] args)
        {
            XmlConfigurator.Configure();

            IThemeSelector selector = new ThemeExcelSelector();
            IStarter starter = new MajestimStarter(selector);

            //starter.Start();
            IContext context = MajestimStarter.Container.Resolve<IContext>();

            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                Test1(uow);
                Test2(uow);
            }
        }
    }
}



//        static void Main_(string[] args)
//        {
//            XmlConfigurator.Configure();

//            using (MySqlConnection mysqlCnx = new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim"))
//            {
//                IContext c = new MyContext(mysqlCnx);
//                IRepository<BIEN> repo = new Repository<BIEN>(c);
//                IEnumerable<BIEN> all = repo.GetAll();

//                foreach (BIEN b in all)
//                {
//                    log.Info($"{b.DESCRIPTION}");
//                }

//                IRepository<CONTRAT> repoContrat = new Repository<CONTRAT>(c);
//                CONTRAT contrat = repoContrat.Single("where nom = 'ALEX/7'");

//                if (contrat != null)
//                    log.Info($"==> {contrat.DATE_ENTREE} {contrat.NOM}");

//                IEnumerable<CONTRAT> allc = repoContrat.GetAll("where date_sortie is not null");

//                foreach (CONTRAT cc in allc)
//                {
//                    //IEnumerable<CONTRAT_LOT> contrat_lot = RepoFactory.CreateFactory<CONTRAT_LOT>(c).GetAll($"where contrat_id={cc.ID}");
//                    IRepository<CONTRAT_LOT> repoContratLot = new Repository<CONTRAT_LOT_Command, CONTRAT_LOT>(c);

//                    IEnumerable<CONTRAT_LOT> contrat_lot = repoContratLot.GetAll($"where contrat_id={cc.ID}");


//                    foreach (CONTRAT_LOT cl in contrat_lot)
//                    {
//                        log.Warn($"id={cl.ID}  lot-id={cl.LOT_ID}");
//                    }
//                }

//                foreach (CONTRAT cc in allc)
//                {
//                    IEnumerable<LOT> lots = mysqlCnx.Query<LOT>($@"
//select b.*
//from contrat_lot cl, bien b
//where cl.lot_id=b.id
//and cl.contrat_id={cc.ID}");

//                    log.Warn($"CONTRAT={cc.NOM}");

//                    foreach (LOT l in lots)
//                    {
//                        log.Warn($"==> LOT={l.DESCRIPTION} - {l.NUMERO}");
//                    }
//                }

//                CONTRAT newContrat = new CONTRAT
//                {
//                    COMMENTAIRE = "Hello",
//                    TYPE_CONTRAT_ID = EnumHelper.ValueOf(mysqlCnx, TYPE_CONTRAT_Enum.box),
//                    NOM = "NewContrat",
//                    DATE_ENTREE = DateTime.Today
//                };

//                repoContrat.Insert(newContrat);
//                //RepoFactory.CreateFactory<CONTRAT>(c).Insert(newContrat);

//                TYPE_CONTRAT_Enum en = EnumHelper.ValueOf<TYPE_CONTRAT_Enum>(mysqlCnx, newContrat.TYPE_CONTRAT_ID);
//            }
//        }


//                IRepository<Bien> repo = new BienRepository(c);
//                var all = repo.GetAll();

//                IRepository<Lot> repo2 = new LotRepository(c);

//                Immeuble imm2 = c.Query<Immeuble>("select b.*, i.* from bien b, immeuble i where b.id=i.id;").FirstOrDefault();

//                IEnumerable<dynamic> r = c.Query("select id, description from Bien;");

//                var res = c.Query<Lot>(@"
//select 
//    b.*,
//    l.*
//from 
//    bien b, lot l 
//where 
//    b.id = l.id
//");


//                Lot lot = c.Query<Lot>(@"
//select 
//    b.*,
//    l.*
//from 
//    bien b, lot l 
//where 
//    b.id = l.id
//and b.numero = @numero",
//                    new { numero = "11" }
//                    ).FirstOrDefault();

//                lot.surface = 789;
//                lot.description = "Helo World";

//                //                c.Execute(@"
//                //update lot set 
//                //    surface=@surface
//                //where id=@id;
//                //update bien set
//                //    description = @description
//                //where id = @id"
//                //                    , lot);

//                //c.Execute("update bien set description=@description where id=@id", lot);

//                Immeuble imm = new Immeuble
//                {
//                    description= "Fabrice",
//                    numero= "5868",
//                    nb_etages = 10,
//                    nb_lots = 123465,
//                    id=49
//                };

//                Immeuble del = new Immeuble
//                    {id = 64};

//                c.Execute(@"
//delete from immeuble where id=@id;
//delete from bien where id=@id;
//", del);


//                c.Execute(@"
//update bien set description=@description where id=@id;
//update immeuble set nb_Lots=@nb_lots where id=@id;
//", imm);

//                int id = c.Query<int>(@"
//insert into bien(description, numero) values (@description, @numero);
//insert into immeuble(id,nb_Lots, nb_Etages, surface) values ( (select LAST_INSERT_ID()), @nb_lots, @nb_etages, @surface);
//select LAST_INSERT_ID();",
//                    imm).Single();

//                //imm.d = id;


/*
    b.description, 
    b.numero, 
    l.etage, 
    l.entree 
*/
/*
 * 

        static void Main_2(string[] args)
        {
            new Dapper_1_N().Main();
        }


        static void Main_1(string[] args)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
*/
