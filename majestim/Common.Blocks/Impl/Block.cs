using System;
using System.Collections.Generic;
using System.Linq;
using Common.Blocks.Interface;

namespace Common.Blocks.Impl
{
    public class Block : IBlock
    {
        //private static string _libPath;

        private List<Block> _nestedBlock = new List<Block>();

        public BlockObject Instance { get; private set; }

        public Block FindBlock(string name)
        {
            return this._nestedBlock.FirstOrDefault(x =>
                x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        //public static void SetLibPath(string path)
        //{
        //    Block._libPath = path;
        //}

        public static IBlock Create(string text, params string[] blocks)
        {
            // 1. injecter les block issus des lib
            //string newText = Block.InjectLib(text);

            IBlock block = new Block("<root>", text, blocks);

            return block;
        }

        //private static string InjectLib(string text)
        //{
        //    Regex re = new Regex(@"\{@[a-zA-Z\}");
        //    return text;
        //}

        private Block(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }

        private  Block(string name, string text, params string[] blocks)
        {
            this.Name = name;
            this.Text = text;

            // créer l'arbre des block
            this.Init(blocks);

            // produire les template
            this.InitTemplate();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitTemplate()
        {
            foreach (Block nestedBlock in this._nestedBlock)
            {
                string name = nestedBlock.Name;
                string begin = "{begin" + name + "}";
                string end = "{end" + name + "}";
                int beginPos = this.Text.IndexOf(begin, StringComparison.InvariantCultureIgnoreCase);
                int endPos = this.Text.IndexOf(end, StringComparison.InvariantCultureIgnoreCase);

                string newText =
                    this.Text.Substring(0, beginPos) +
                    "{__BLOCK__" + name + "}" +
                    this.Text.Substring(endPos + end.Length);

                this.Text = newText;

                // sub
                nestedBlock.InitTemplate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="blocks"></param>
        private void Init(string[] blocks)
        {
            foreach (string block in blocks)
            {
                string[] ls = block.Split('/');
                Block currBlock = this;

                foreach (string s in ls)
                {
                    Block nestedBlock = currBlock.FindBlock(s);

                    currBlock = nestedBlock ?? currBlock.CreateBlock(s);
                }
            }
        }

        /// <summary>
        /// cration du block inclus
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Block CreateBlock(string s)
        {
            string begin = "{begin" + s + "}";
            string end = "{end" + s + "}";
            int beginPos = this.Text.IndexOf(begin, StringComparison.InvariantCultureIgnoreCase);
            int endPos = this.Text.IndexOf(end, StringComparison.InvariantCultureIgnoreCase);

            if (beginPos == -1 || endPos == -1)
                throw new Exception($"Le block '{s}' n'existe pas.");

            string nestedBlockText = this.Text.Substring(beginPos + begin.Length, endPos - (beginPos + begin.Length));

            //string newText =
            //    this.Text.Substring(0, beginPos) +
            //    "{__BLOCK__" + s + "}" +
            //    this.Text.Substring(endPos + end.Length);

            //this.Text = newText;

            Block newBlock = new Block(s, nestedBlockText);
            this._nestedBlock.Add(newBlock);

            return newBlock;
        }

        //public string Begin { get; }
        //public string End { get; }
        //public int BeginPos { get; private set; }
        //public int EndPos { get; private set; }
        public string Text { get; private set; }
        public string Name { get; }

        public IBlockObject Instanciate()
        {
            this.Instance = new BlockObject(this);

            return this.Instance;
        }

    }
}

