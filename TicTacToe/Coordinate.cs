using System;

namespace TicTacToe
{
    public class Coordinate : IEquatable<Coordinate>
    {
        private readonly int _row;
        private readonly int _column;

        public Coordinate(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public bool Equals(Coordinate other)
        {
            if(other == null) return false;

            return _row == other._row && 
                   _column == other._column;
        }

        public bool CompareRow(Coordinate other)
        {
            if (other == null) return false;
            return _row == other._row;
        }
    }
}