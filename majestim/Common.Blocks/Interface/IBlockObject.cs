using System.Collections.Generic;

namespace Common.Blocks.Interface
{
    public interface IBlockObject
    {
        /// <summary>
        /// 
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsOdd { get; }

        /// <summary>
        /// instancie le texte d'un block de cette instance
        /// </summary>
        /// <returns></returns>
        IBlockObject Instanciate(string blockName, params object[] fieldValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        IBlockObject Subs(params object[] fieldValue);

        /// <summary>
        /// fourni la valeur string du block instancié
        /// </summary>
        /// <returns></returns>
        string Eval(params string[] removeEmptyBlocks);
    }
}



/// <summary>
/// liste des blocks instanciés d'un block donné
/// </summary>
/// <param name="blockName"></param>
/// <returns></returns>
//IEnumerable<IBlockObjectRow> BlockRows(string blockName);
