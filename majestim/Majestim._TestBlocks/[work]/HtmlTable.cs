using Common.Blocks.Impl;
using Common.Blocks.Interface;

namespace Majestim._TestBlocks.Resource
{
    public class HtmlTable<T>
    {
        private T _columns;
        private IBlock _root;
        private IBlockObject _rootInstance;

        public HtmlTable(T columns, string htmlTemplate)
        {
            this._columns = columns;
            this._root = Block.Create(htmlTemplate, "Init", "Table", "Table/Header", "Table/Row", "Table/Row/Col");
            this._rootInstance = this._root.Instanciate();
        }
    }
}