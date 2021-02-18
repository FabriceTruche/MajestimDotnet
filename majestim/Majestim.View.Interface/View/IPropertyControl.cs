namespace Majestim.View.Interface.View
{
    public interface IPropertyControl
    {
        void AddField(string name);
        void AddList(string name, string list);
        void AddCheckBox(string name, bool initialValue);

        /// <summary>
        /// retourne la valeur d'un champs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T ValueOf<T>(string name);
    }
}