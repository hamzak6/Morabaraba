﻿namespace Morabaraba
{
    /// <inheritdoc />
    /// <summary>
    /// Shoot determiner implementation
    /// </summary>
    public class ShootDeterminer : IShootDeterminer
    {
        private readonly IGame _game;
        
        public bool CanShoot(Colour player)
        {
            return
                _game.Board.AreMillsDifferent(
                    _game.Player(player).ForbiddenMills,
                    _game.Board.Mills(player));
        }

        public ShootDeterminer(IGame game)
        {
            _game = game;
        }
    }
}