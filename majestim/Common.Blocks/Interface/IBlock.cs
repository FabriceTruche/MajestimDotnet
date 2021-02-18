namespace Common.Blocks.Interface
{
    public interface IBlock
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// instancie le block de texte correspondant au block lui-même
        /// </summary>
        /// <returns></returns>
        IBlockObject Instanciate();

        /// <summary>
        /// retourne le texte du block
        /// </summary>
        string Text { get; }
    }
}