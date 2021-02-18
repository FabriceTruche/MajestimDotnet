using BrightIdeasSoftware;

namespace Majestim.View.Interface.Editor
{
    public interface ICustomEditor
    {
        void Init(CellEditEventArgs ce);
        void Validate(CellEditEventArgs ce);
    }
}