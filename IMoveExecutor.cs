using System;

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
        /// <exception cref="ArgumentException">Thrown when coordinates are empty</exception>
        /// <exception cref="ArgumentNullException">Thrown when coordinates are null</exception>
        Move Execute(Move move, Coordinate[] coordinates);
    }
}