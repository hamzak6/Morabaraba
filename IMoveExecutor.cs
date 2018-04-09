﻿using System;

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
        /// <returns>Potential error</returns>
        /// <exception cref="ArgumentException">Thrown when move is game end move</exception>
        string Execute(Move move, Coordinate[] coordinates);
    }
}