using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Symbol { get; set; }

        public bool CompareRow(int row)
        {
            return this.Row == row;
        }
    }

    public class Board
    {
        private readonly List<Tile> _plays = new List<Tile>();

        public Board()
        {
        }
        public Tile TileAt(int row, int column)
        {
            return _plays.FirstOrDefault(tile => tile.Row == row && tile.Column == column);
        }

        public void AddTileAt(char symbol, int row, int column)
        {
            _plays.Add(new Tile { Row = row, Column = column, Symbol = symbol });
        }
    }

    public class Game
    {
        private char _lastSymbol = 'O';
        private readonly Board _board = new Board();

        public void Play(char symbol, int row, int column)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid player");
            }
            
            if (_board.TileAt(row, column) != null)
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, row, column);
        }

        public char Winner()
        {
            if (_board.TileAt(0, 0) != null &&
               _board.TileAt(0, 1) != null &&
               _board.TileAt(0, 2) != null)
            {
                //if first row is full with same symbol
                if (_board.TileAt(0, 0).Symbol ==
                    _board.TileAt(0, 1).Symbol &&
                    _board.TileAt(0, 2).Symbol ==
                    _board.TileAt(0, 1).Symbol)
                {
                    return _board.TileAt(0, 0).Symbol;
                }
            }

            if (_board.TileAt(1, 0) != null &&
               _board.TileAt(1, 1) != null &&
               _board.TileAt(1, 2) != null)
            {
                //if middle row is full with same symbol
                if (_board.TileAt(1, 0).Symbol ==
                    _board.TileAt(1, 1).Symbol &&
                    _board.TileAt(1, 2).Symbol ==
                    _board.TileAt(1, 1).Symbol)
                {
                    return _board.TileAt(1, 0).Symbol;
                }
            }

            if (_board.TileAt(2, 0) != null &&
               _board.TileAt(2, 1) != null &&
               _board.TileAt(2, 2) != null)
            {
                //if middle row is full with same symbol
                if (_board.TileAt(2, 0).Symbol ==
                    _board.TileAt(2, 1).Symbol &&
                    _board.TileAt(2, 2).Symbol ==
                    _board.TileAt(2, 1).Symbol)
                {
                    return _board.TileAt(2, 0).Symbol;
                }
            }

            return ' ';
        }
    }
}