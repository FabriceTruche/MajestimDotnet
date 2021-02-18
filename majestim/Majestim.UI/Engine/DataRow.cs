namespace Majestim.UI.Engine
{
    internal class DataRow<T>
    {
        public DataRow()
        {
            State = StateObject.NotChanged;
        }

        public T RowObject { get; set; }
        public StateObject State { get; set; }
    }
}