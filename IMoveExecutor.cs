namespace Morabaraba
{
    /// <summary>
    /// Move executor interface
    /// </summary>
    public interface IMoveExecutor
    {
        /// <summary>
        /// Executes the move
        /// </summary>
        /// <param name="move">The move to be executed</param>
        /// <param name="coordinates">The coordinates to be used for the execution</param>
        /// <returns>The next move</returns>
        Move Execute(Move move, Coordinate[] coordinates);
    }
}