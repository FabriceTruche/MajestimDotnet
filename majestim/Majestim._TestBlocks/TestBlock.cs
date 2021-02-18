
//using _console1.BlockNs.Interface;
//using System;
//using System.IO;

//namespace _console1.BlockNs
//{
//    class DataItem
//    {
//        public int level { get; set; }
//        public string firstName { get; set; }
//        public string lastName { get; set; }
//        public string mail{ get; set; }
//        public string lib => $"level --> {this.level}";
//    }

//    class TestBlock
//    {
//        public void Run()
//        {
//            var dataHeader = new[]
//            {
//                "First name", "Last Name", "Mail"
//            };

//            var data = new[]
//            {
//                new DataItem()
//                {
//                    level = 1,
//                    firstName = "toto",
//                    lastName = "titi",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 2,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 3,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 3,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 3,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 4,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 2,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 3,
//                    firstName = "Fabrice",
//                    lastName = "xxxx",
//                    mail = "aa@bidule.com",
//                },
//                new DataItem()
//                {
//                    level = 3,
//                    firstName = "Christine",
//                    lastName = "Bidule",
//                    mail = "aa@bidule.com",
//                }
//            };

//            // path de la lib
//            //Block.SetLibPath(@"C:\Users\Fabrice\Documents\Visual Studio 2017\Projects\model\EaAddins\_console1\TestBlock");

//            // nom de la table
//            string tableName = "test1";

//            // block template
//            IBlock block = Block.Create(Resource1.testTV, "Init", "Table", "Table/Header", "Table/Row", "Table/Row/Col");

//            // page instanciée
//            IBlockObject htmlPage = block.Instanciate();
//            IBlockObject jssBlock = htmlPage.Instanciate("Init");
//            IBlockObject tableBlock = htmlPage.Instanciate("Table");

//            jssBlock.Subs("tableName", tableName);
//            tableBlock.Subs("tableName", tableName);

//            foreach (string ls in dataHeader)
//            {
//                IBlockObject header = tableBlock.Instanciate("Header");
//                header.Subs("colName", ls);
//            }

//            this.AddData(tableBlock, new DataItem()
//            {
//                firstName = "Root",
//                lastName = "Element racine",
//                level = 0
//            },0);

//            int index = 1;

//            for (int i=0; i<2;i++)
//                foreach (DataItem item in data)
//                    this.AddData(tableBlock, item, index++);

//            string res = htmlPage.Eval();

//            File.WriteAllText(@"C:\Users\Fabrice\Documents\Visual Studio 2017\Projects\model\EaAddins\_console1\TestBlock\testGen.html", res);

//            Console.WriteLine(res.Length);
//        }

//        void AddData(IBlockObject bo, DataItem item, int index)
//        {
//            // row
//            IBlockObject row = bo.Instanciate("Row");
//            row.Subs("level", (item.level+1).ToString());

//            // 3 cols
//            row.Instanciate("Col").Subs("tableCellText", item.lib);
//            row.Instanciate("Col").Subs("tableCellText", item.firstName);
//            row.Instanciate("Col").Subs("tableCellText", $"{index} - {item.mail}");
//        }
//    }
//}



//    /*
//                // row
//                IBlockObject row = tableBlock.Instanciate("Row");
//                row.Subs("level", item.level.ToString());

//                // 3 cols
//                row.Instanciate("Col").Subs("tableCellText", item.lib);
//                row.Instanciate("Col").Subs("tableCellText", item.firstName);
//                row.Instanciate("Col").Subs("tableCellText", item.mail);
//            }
//             */