namespace Majestim.UI.Command
{
    public class BienCommand : ItemCommand
    {
        public BienCommand(ItemCommand parent) : base(parent,"Gestion des Biens")
        {
            Text = "Gestion des Biens";
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
        }
    }
}