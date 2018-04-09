using System;

namespace Morabaraba
{
    public class MoveExecutor : IMoveExecutor
    {
        private readonly IGame _game;

        private IPlayer Player(Colour colour)
        {
            return colour == Colour.Light
                ? _game.LightPlayer
                : _game.DarkPlayer;
        }
        
        private string Place(Coordinate coordinate, Colour cow)
        {
            if (_game.Board.IsOccupied(coordinate))
                return "Cannot occupy an occupied coordinate. Try again!";
            _game.Board.Place(coordinate, cow);
            Player(cow).Placed();
            return null;
        }

        private string MoveCow(Coordinate source, Coordinate destination)
        {
            return !_game.Board.Adjacent(source, destination)
                ? "Cannot move between non-adjacent coordinates. Try again!"
                : Fly(source, destination);
        }

        private string Fly(Coordinate source, Coordinate destination)
        {
            if (!_game.Board.IsOccupied(source))
                return "Cannot unoccupy an unoccupied coordinate. Try again!";
            if (_game.Board.IsOccupied(destination))
                return "Cannot occupy and occupied coordinate. Try again!";
            var cow = _game.Board.Occupant(source);
            _game.Board.Displace(source);
            return Place(destination, cow);
        }

        private string Shoot(Coordinate coordinate)
        {
            if (!_game.Board.IsOccupied(coordinate))
                return "Cannot shoot at nothing. Try again!";
            var cow = _game.Board.Occupant(coordinate);
            _game.Board.Displace(coordinate);
            Player(cow).Shot();
            return null;
        }
        
        public string Execute(Move move, Coordinate[] coordinates)
        {
            switch (move)
            {
                case Move.Draw:
                case Move.DarkWins:
                case Move.LightWins:
                    throw new InvalidOperationException();
                case Move.DarkPlace:
                    return Place(coordinates[0], Colour.Dark);
                case Move.LightPlace:
                    return Place(coordinates[0], Colour.Light);
                case Move.DarkMove:
                case Move.LightMove:
                    return MoveCow(coordinates[0], coordinates[1]);
                case Move.DarkFly:
                case Move.LightFly:
                    return Fly(coordinates[0], coordinates[1]);
                case Move.DarkShoot:
                case Move.LightShoot:
                    return Shoot(coordinates[0]);
                default:
                    throw new ArgumentException();
            }
        }

        public MoveExecutor(IGame game)
        {
            _game = game;
        }
    }
}