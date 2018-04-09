﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Morabaraba
{
    /// <summary>
    /// A Morabaraba Board
    /// </summary>
    public class Board : IBoard
    {
        private enum Line
        {
            Row,
            Column,
            Diagonal
        }
        
        private readonly IDictionary<Coordinate, Colour> _occupations;
        private readonly IDictionary<Coordinate, Dictionary<Coordinate, Line>> _coordinates;

        public Board()
        {
            _occupations = new Dictionary<Coordinate, Colour>();
            _coordinates = new Dictionary<Coordinate, Dictionary<Coordinate, Line>>
            {
                { Coordinate.A1, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Row }, { Coordinate.B2, Line.Diagonal }, { Coordinate.D1, Line.Column } } },
                { Coordinate.A4, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Row }, { Coordinate.A7, Line.Row }, { Coordinate.B4, Line.Column } } },
                { Coordinate.A7, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Row }, { Coordinate.B6, Line.Diagonal }, { Coordinate.D7, Line.Column } } },
                { Coordinate.B2, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Diagonal }, { Coordinate.B4, Line.Row }, { Coordinate.C3, Line.Diagonal }, { Coordinate.D2, Line.Column } } },
                { Coordinate.B4, new Dictionary<Coordinate, Line> { { Coordinate.A4, Line.Column }, { Coordinate.B2, Line.Row }, { Coordinate.B6, Line.Row }, { Coordinate.C4, Line.Column } } },
                { Coordinate.B6, new Dictionary<Coordinate, Line> { { Coordinate.A7, Line.Diagonal }, { Coordinate.B4, Line.Row }, { Coordinate.C5, Line.Diagonal }, { Coordinate.D6, Line.Column } } },
                { Coordinate.C3, new Dictionary<Coordinate, Line> { { Coordinate.B2, Line.Diagonal }, { Coordinate.C4, Line.Row }, { Coordinate.D3, Line.Column } } },
                { Coordinate.C4, new Dictionary<Coordinate, Line> { { Coordinate.B4, Line.Column }, { Coordinate.C3, Line.Row }, { Coordinate.C5, Line.Row } } },
                { Coordinate.C5, new Dictionary<Coordinate, Line> { { Coordinate.B6, Line.Diagonal }, { Coordinate.C4, Line.Row }, { Coordinate.D5, Line.Column } } },
                { Coordinate.D1, new Dictionary<Coordinate, Line> { { Coordinate.A1, Line.Column }, { Coordinate.D2, Line.Row }, { Coordinate.G1, Line.Column } } },
                { Coordinate.D2, new Dictionary<Coordinate, Line> { { Coordinate.B2, Line.Column }, { Coordinate.D1, Line.Row }, { Coordinate.D3, Line.Row }, { Coordinate.F2, Line.Column } } },
                { Coordinate.D3, new Dictionary<Coordinate, Line> { { Coordinate.C3, Line.Column }, { Coordinate.D2, Line.Row }, { Coordinate.E3, Line.Column } } },
                { Coordinate.D5, new Dictionary<Coordinate, Line> { { Coordinate.C5, Line.Column }, { Coordinate.D6, Line.Row }, { Coordinate.E5, Line.Column } } },
                { Coordinate.D6, new Dictionary<Coordinate, Line> { { Coordinate.B6, Line.Column }, { Coordinate.D5, Line.Row }, { Coordinate.D7, Line.Row }, { Coordinate.F6, Line.Column } } },
                { Coordinate.D7, new Dictionary<Coordinate, Line> { { Coordinate.A7, Line.Column }, { Coordinate.D6, Line.Row }, { Coordinate.G7, Line.Column } } },
                { Coordinate.E3, new Dictionary<Coordinate, Line> { { Coordinate.D3, Line.Column }, { Coordinate.E4, Line.Row }, { Coordinate.F2, Line.Diagonal } } },
                { Coordinate.E4, new Dictionary<Coordinate, Line> { { Coordinate.E3, Line.Row }, { Coordinate.E5, Line.Row }, { Coordinate.F4, Line.Column } } },
                { Coordinate.E5, new Dictionary<Coordinate, Line> { { Coordinate.D5, Line.Column }, { Coordinate.E4, Line.Row }, { Coordinate.F6, Line.Diagonal } } },
                { Coordinate.F2, new Dictionary<Coordinate, Line> { { Coordinate.D2, Line.Column }, { Coordinate.E3, Line.Diagonal }, { Coordinate.F4, Line.Row }, { Coordinate.G1, Line.Diagonal } } },
                { Coordinate.F4, new Dictionary<Coordinate, Line> { { Coordinate.E4, Line.Column }, { Coordinate.F2, Line.Row }, { Coordinate.F6, Line.Row }, { Coordinate.G4, Line.Column } } },
                { Coordinate.F6, new Dictionary<Coordinate, Line> { { Coordinate.D6, Line.Column }, { Coordinate.E5, Line.Diagonal }, { Coordinate.F4, Line.Row }, { Coordinate.G7, Line.Diagonal } } },
                { Coordinate.G1, new Dictionary<Coordinate, Line> { { Coordinate.D1, Line.Column }, { Coordinate.F2, Line.Diagonal }, { Coordinate.G4, Line.Row } } },
                { Coordinate.G4, new Dictionary<Coordinate, Line> { { Coordinate.F4, Line.Column }, { Coordinate.G1, Line.Row }, { Coordinate.G7, Line.Row } } },
                { Coordinate.G7, new Dictionary<Coordinate, Line> { { Coordinate.D7, Line.Column }, { Coordinate.F6, Line.Diagonal }, { Coordinate.G4, Line.Row } } }
            };
        }

        private bool Adjacent(Coordinate a, Coordinate b, out Line line)
        {
            if (_coordinates[a].ContainsKey(b))
            {
                line = _coordinates[a][b];
                return true;
            }
            line = Line.Row;
            return false;
        }
        
        public bool Adjacent(Coordinate a, Coordinate b)
        {
            return Adjacent(a, b, out Line _);
        }

        public void Place(Coordinate coordinate, Colour cow)
        {
            if (IsOccupied(coordinate))
                throw new InvalidOperationException();
            _occupations[coordinate] = cow;
        }

        public void Displace(Coordinate coordinate)
        {
            if (!IsOccupied(coordinate))
                throw new InvalidOperationException();
            _occupations.Remove(coordinate);
        }

        private List<Coordinate> Neighbours(Coordinate coordinate)
        {
            return _coordinates[coordinate].Keys.ToList();
        }

        private List<List<Coordinate>> Lines(Coordinate coordinate)
        {
            var neighbours = Neighbours(coordinate);
            var neighboursNeighbours = neighbours.Select(Neighbours) as List<List<Coordinate>>;
            var lines = new List<List<Coordinate>>();
            for (var i = 0; i < neighbours.Count; i++)
            {
                var neighbour = neighbours[i];
                if (neighboursNeighbours == null)
                    continue;
                for (var j = 0; j < neighboursNeighbours[i].Count; j++)
                {
                    var neighboursNeighbour = neighboursNeighbours[i][j];
                    var line1 = _coordinates[coordinate][neighbour];
                    var line2 = _coordinates[neighbour][neighboursNeighbour];
                    if (line1 == line2)
                        lines.Add(new List<Coordinate>() {neighbour, neighboursNeighbour});
                }
            }
            return lines;
        }
        
        public bool InAMill(Coordinate coordinate)
        {
            var mills = Mills(coordinate);
            return mills != null && mills.Length >= 1;
        }

        public bool InAMill(Colour player)
        {
            return _occupations.Any(occupation => occupation.Value == player && InAMill(occupation.Key));
        }

        public bool AllInAMill(Colour player)
        {
            var cows = _occupations.
                Select(x => x.Value == player).
                Count();
            var mills = _occupations
                .Where(x => x.Value == player)
                .Select(x => InAMill(x.Key))
                .Count();
            return cows == mills; // Making use of the duplication
        }

        public bool IsOccupied(Coordinate coordinate)
        {
            return _occupations.ContainsKey(coordinate);
        }

        public Colour Occupant(Coordinate coordinate)
        {
            return _occupations[coordinate];
        }
        
        // There is duplication in this method. The duplication is used in other methods.
        public Coordinate[][] Mills(Coordinate coordinate)
        {
            if (!IsOccupied(coordinate))
                throw new InvalidOperationException();
            var occupant = Occupant(coordinate);
            var lines = Lines(coordinate);
            var mills = new Coordinate[lines.Count][];
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (!(IsOccupied(line[0]) && IsOccupied(line[1])))
                    continue;
                if (!(Occupant(line[0]) == occupant && occupant == Occupant(line[1])))
                    continue;
                var mill = new List<Coordinate>() {coordinate, line[0], line[1]};
                mill.Sort();
                mills[i] = mill.ToArray();
            }
            return mills;
        }

        public Coordinate[][] Mills(Colour player)
        {
            var millList = _occupations
                .Where(occupation => occupation.Value == player)
                .Where(occupation => InAMill(occupation.Key))
                .Select(occupation => Mills(occupation.Key))
                .ToList();
            var x = millList.SelectMany(i => i);
            return x.ToArray();
        }
        
        private char OccupantChar(Coordinate coordinate)
        {
            if (!_occupations.ContainsKey(coordinate))
                return 'o';
            switch (_occupations[coordinate])
            {
                case Colour.Dark:
                    return 'D';
                default:
                    return 'L';
            }
        }

        public override string ToString()
        {
            return
            $@"
                                                                    1   2   3   4   5   6   7
                                                                A   {OccupantChar(Coordinate.A1)}-----------{OccupantChar(Coordinate.A4)}-----------{OccupantChar(Coordinate.A7)}
                                                                    | \         |         / |
                                                                B   |   {OccupantChar(Coordinate.B2)}-------{OccupantChar(Coordinate.B4)}-------{OccupantChar(Coordinate.B6)}   |
                                                                    |   | \     |     / |   |
                                                                C   |   |   {OccupantChar(Coordinate.C3)}---{OccupantChar(Coordinate.C4)}---{OccupantChar(Coordinate.C5)}   |   |
                                                                    |   |   |       |   |   |
                                                                D   {OccupantChar(Coordinate.D1)}---{OccupantChar(Coordinate.D2)}---{OccupantChar(Coordinate.D3)}       {OccupantChar(Coordinate.D5)}---{OccupantChar(Coordinate.D6)}---{OccupantChar(Coordinate.D7)}
                                                                    |   |   |       |   |   |
                                                                E   |   |   {OccupantChar(Coordinate.E3)}---{OccupantChar(Coordinate.E4)}---{OccupantChar(Coordinate.E5)}   |   |
                                                                    |   | /     |     \ |   |
                                                                F   |   {OccupantChar(Coordinate.F2)}-------{OccupantChar(Coordinate.F4)}-------{OccupantChar(Coordinate.F6)}   |
                                                                    | /         |         \ |
                                                                G   {OccupantChar(Coordinate.G1)}-----------{OccupantChar(Coordinate.G4)}-----------{OccupantChar(Coordinate.G7)}
            ";
}
    }
}