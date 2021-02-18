namespace Majestim.DAL.Interface.DAL
{
    public interface IEnumHelper
    {
        int GetValueId<T>(T value);
        T GetValue<T>(int id) where T : new();
    }
}