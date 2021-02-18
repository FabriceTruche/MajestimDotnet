using System.Windows.Forms;

namespace Majestim.Helpers
{
    public static class ClipboardHelper
    {
        public static string ClipboarData()
        {
            IDataObject clip = Clipboard.GetDataObject();
            if (clip!=null && clip.GetDataPresent(DataFormats.Text))
                return clip.GetData(DataFormats.Text) as string;

            return "";
        }
    }
}

