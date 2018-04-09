namespace Morabaraba
{
    public class MoveDeterminer : IMoveDeterminer
    {
        private readonly IGame _game;
        private readonly ITurnDeterminer _turnDeterminer;
        private readonly IShootDeterminer _shootDeterminer;
        private int _flightsWithoutShots;
        
        public Move CurrentMove
        {
            get
            {
                if ((_game.DarkPlayer.Phase == Phase.Flying || _game.LightPlayer.Phase == Phase.Flying) &&
                    !_shootDeterminer.CanShoot)
                    _flightsWithoutShots++;
                if (_shootDeterminer.CanShoot)
                    _flightsWithoutShots = 0;
                const int turnLimitForDraw = 10;
                if (turnLimitForDraw == _flightsWithoutShots ||
                    _game.Board.AllCoordinatesOccupied && !_shootDeterminer.CanShoot)
                    return Move.Draw;
                const int limitForLoss = 2;
                if (_game.DarkPlayer.CowsLeft == limitForLoss)
                    return Move.LightWins;
                if (_game.LightPlayer.CowsLeft == limitForLoss)
                    return Move.DarkWins;
                if (_turnDeterminer.Turn == Colour.Dark)
                {
                    if (_shootDeterminer.CanShoot)
                        return Move.DarkShoot;
                    switch (_game.DarkPlayer.Phase)
                    {
                        case Phase.Placing:
                            return Move.DarkPlace;
                        case Phase.Moving:
                            return Move.DarkMove;
                        case Phase.Flying:
                            return Move.DarkFly;
                    }
                }
                else
                {
                    if (_shootDeterminer.CanShoot)
                        return Move.LightShoot;
                    switch (_game.LightPlayer.Phase)
                    {
                        case Phase.Placing:
                            return Move.LightPlace;
                        case Phase.Moving:
                            return Move.LightMove;
                        case Phase.Flying:
                            return Move.LightFly;
                    }
                }
                return Move.DarkPlace;
            }
        }

        public MoveDeterminer(ITurnDeterminer turnDeterminer, IShootDeterminer shootDeterminer, IGame game)
        {
            _turnDeterminer = turnDeterminer;
            _shootDeterminer = shootDeterminer;
            _game = game;
            _flightsWithoutShots = 0;
        }
    }
}