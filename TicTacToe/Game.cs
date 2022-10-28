﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class Coordinate
    {
        private readonly int _row;
        private readonly int _column;

        public Coordinate(int row, int column)
        {
            _row = row;
            _column = column;
        }
    }

    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Symbol { get; set; }

        public Tile(char symbol, int row, int column)
        {
            Symbol = symbol;
            Row = row;
            Column = column;
        }

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
            _plays.Add(new Tile(symbol, row, column));
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
            var rowIndex = 0;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).Symbol;
            }

            rowIndex = 1;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).Symbol;
            }

            rowIndex = 2;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).Symbol;
            }

            return ' ';
        }

        private bool RowTilesMatch(int rowIndex)
        {
            return _board.TileAt(rowIndex, 0).Symbol ==
                   _board.TileAt(rowIndex, 1).Symbol &&
                   _board.TileAt(rowIndex, 2).Symbol ==
                   _board.TileAt(rowIndex, 1).Symbol;
        }

        private bool IsRowPopulated(int rowIndex)
        {
            return _board.TileAt(rowIndex, 0) != null &&
                   _board.TileAt(rowIndex, 1) != null &&
                   _board.TileAt(rowIndex, 2) != null;
        }
    }
}