namespace Majestim.BL.Interface.OperationBase.Compta
{
    public static class ComptesEx
    {
        public static string Text(this Comptes comptes)
        {
            return comptes.ToString().Substring(2);
        }
    }
}