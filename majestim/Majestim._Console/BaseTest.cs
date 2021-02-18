using System;
using System.Dynamic;
using log4net.Config;
using Majestim.Application.Conf;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using Unity;
using YamlDotNet.Serialization;

namespace Majestim._Console
{
    public class BaseTest
    {
        protected IUnitOfWork Uow { get; set; }

        [OneTimeSetUp]
        protected void ClassInitialize()
        {
            XmlConfigurator.Configure();

            IThemeSelector selector = new ThemeExcelSelector();
            IStarter starter = new MajestimStarter(selector);

            //starter.Start();
            IContext context = MajestimStarter.Container.Resolve<IContext>();

            this.Uow = new UnitOfWork(context);
        }

        [OneTimeTearDown]
        protected void Cleanup()
        {
            this.Uow.Dispose();
        }

        protected void Dump(object obj)
        {
            string res = JsonConvert.SerializeObject(obj);
            ExpandoObjectConverter expConverter = new ExpandoObjectConverter();
            dynamic deserializedObject =
                JsonConvert.DeserializeObject<ExpandoObject>(res, expConverter);
            Serializer serializer = new Serializer();
            string jsonContent = serializer.Serialize(deserializedObject);

            Console.WriteLine(jsonContent);
        }
    }
}