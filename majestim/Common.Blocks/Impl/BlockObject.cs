using System;
using System.Collections.Generic;
using System.Linq;
using Common.Blocks.Interface;

namespace Common.Blocks.Impl
{
    public class BlockObject : IBlockObject
    {
        private readonly Block _block;
        private string _instanceText;

        private readonly Dictionary<Block, List<BlockObject>> _instancesBlock =
            new Dictionary<Block, List<BlockObject>>();

        public BlockObject(Block block)
        {
            this._block = block;
            this._instanceText = block.Text;
        }

        public string Eval(params string[] removeEmptyBlocks)
        {
            // 1. parcourir les block
            foreach (KeyValuePair<Block, List<BlockObject>> pair in this._instancesBlock)
            {
                // 1.1. text concaneter des insatnces
                string textBlock = this.TextOfBlock(pair.Value);

                // 1.2. subs
                string key = "{__BLOCK__" + pair.Key.Name + "}";

                this._instanceText = this._instanceText.Replace(key, textBlock);
            }

            foreach (string emptyBlock in removeEmptyBlocks)
            {
                this._instanceText = this._instanceText.Replace("{" + emptyBlock + "}", "");
                this._instanceText = this._instanceText.Replace("{__BLOCK__" + emptyBlock + "}", "");
            }

            // 2. pour chacun parcourir les valeur
            // 3. concatener
            return this._instanceText;
        }

        private string TextOfBlock(List<BlockObject> pairValue)
        {
            string res = "";

            foreach (BlockObject item in pairValue)
            {
                res += item.Eval();
            }
            return res;
        }

        //public IEnumerable<IBlockObjectRow> BlockRows(string blockName)
        //{
        //    Block newBlock = this._block.FindBlock(blockName);

        //    if (newBlock == null || !this._instancesBlock.ContainsKey(newBlock))
        //        return null;

        //    List<BlockObject> values = this._instancesBlock[newBlock];
        //    int index = 0;

        //    return values.Select(x =>
        //    {
        //        IBlockObjectRow row = new BlockObjectRow
        //        {
        //            Index = index,
        //            IsOdd = index%2 == 1,
        //            Text = x._instanceText
        //        };

        //        index++;

        //        return row;
        //    });
        //}

        public int Index { get; private set; }

        public bool IsOdd => this.Index % 2 == 1;

        public IBlockObject Instanciate(string blockName, params object[] fieldValue)
        {
            Block newBlock = this._block.FindBlock(blockName);

            if (newBlock == null)
                return null;

            if (!this._instancesBlock.ContainsKey(newBlock))
                this._instancesBlock.Add(newBlock, new List<BlockObject>());

            List<BlockObject> values = this._instancesBlock[newBlock];
            BlockObject bo = new BlockObject(newBlock) {Index = values.Count};

            values.Add(bo);

            bo.Subs(fieldValue);

            return bo;
        }

        private IBlockObject Subs(string fieldName, string value)
        {
            this._instanceText = this._instanceText.Replace("{" + fieldName + "}", value);

            return this;
        }

        public IBlockObject Subs(params object[] fieldValue)
        {
            if (fieldValue.Length % 2 != 0)
                throw new Exception("Subs with params must have [field,value] parameters");

            for (int i = 0; i < fieldValue.Length; i += 2)
            {
                object key = fieldValue[i];
                object value = fieldValue[i + 1];

                if (key != null)
                    this.Subs(key.ToString(), value?.ToString() ?? "");
            }
            return this;
        }
    }
}