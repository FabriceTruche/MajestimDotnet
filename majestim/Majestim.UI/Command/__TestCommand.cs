//using System.Collections.Generic;
//using System.Drawing;
//using Majestim.Interface.Command;

//namespace Majestim.BL.Command
//{
//    public class TestCommand : ICommand
//    {
//        public TestCommand()
//        {
//            // test pour le niveau 1 de l'explorer
//            this.AddItems("item1:hello:world,item2:toto:titi,item3:aaaaaaaa");

//        }

//        private void AddItems(string items)
//        {
//            string[] ls = items.Split(',');

//            this.SubCommands = new List<ICommand>();
//            foreach (string s in ls)
//            {
//                string[] subs = s.Split(':');
//                GroupCommand itemNode = new GroupCommand { Text = subs[0] };
//                this.SubCommands.Add(itemNode);

//                itemNode.SubCommands=new List<ICommand>();
//                for (int i=1; i<subs.Length; i++)
//                {
//                    GroupCommand subsNode = new GroupCommand { Text = subs[i] };
//                    itemNode.SubCommands.Add(subsNode);

//                }
//            }
//        }


//        public string Text { get; set; }
//        public Icon Icon { get; set; }
//        public IList<ICommand> SubCommands { get; set; }
//        public void Execute()
//        {
//        }
//    }
//}