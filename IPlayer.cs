﻿using System;

namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba Player interface
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Called every time a player's cow is placed
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method is called after the 12th time</exception>
        void Placed();
        
        /// <summary>
        /// Called every time a player's cow is shot
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method is called after 10th time</exception>
        void Shot();
        
        /// <summary>
        /// Gets or sets the mill to not be formed on the next move
        /// </summary>
        Coordinate[] ForbiddenMill { get; set; }
        
        /// <summary>
        /// Gets the phase the player is in
        /// </summary>
        Phase Phase { get; }
    }
}