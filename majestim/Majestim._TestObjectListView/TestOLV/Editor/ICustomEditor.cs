using BrightIdeasSoftware;

namespace Majestim._TestObjectListView.TestOLV.Editor
{
    public interface ICustomEditor
    {
        void Init(CellEditEventArgs ce);
        void Validate(CellEditEventArgs ce);
    }
}