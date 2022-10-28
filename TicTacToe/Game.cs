﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public enum Token
    {
        X,
        O
    }
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
    }

    public class Tile
    {
        private readonly Token _symbol;
        private readonly Coordinate _coordinate;

        public Tile(Token symbol, Coordinate coordinate)
        {
            _coordinate = coordinate;
            _symbol = symbol;
        }

        public bool CompareCoordinate(Coordinate other)
        {
            return _coordinate.Equals(other);
        }

        public bool CompareSymbol(Tile other)
        {
            if(other == null) return false;
            return other._symbol == _symbol;
        }

        public Token GetToken()
        {
            return _symbol;
        }

    }

    public class Board
    {
        private readonly List<Tile> _plays = new List<Tile>();

        public Tile TileAt(int row, int column)
        {
            return _plays.FirstOrDefault(tile => tile.CompareCoordinate(new Coordinate(row, column)));
        }

        public void AddTileAt(Token symbol, int row, int column)
        {
            _plays.Add(new Tile(symbol, new Coordinate(row, column)));
        }
    }

    public class Game
    {
        private Token _lastSymbol = Token.O;
        private readonly Board _board = new Board();

        public void Play(Token symbol, int row, int column)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid player");
            }

            if (_board.TileAt(row, column) != null)
            {
                throw new Exception("Invalid position");
            }

            _lastSymbol = symbol;
            _board.AddTileAt(symbol, row, column);
        }

        public Token? Winner()
        {
            var rowIndex = 0;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).GetToken();
            }

            rowIndex = 1;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).GetToken();
            }

            rowIndex = 2;
            if (IsRowPopulated(rowIndex) && RowTilesMatch(rowIndex))
            {
                return _board.TileAt(rowIndex, 0).GetToken();
            }

            return null;
        }

        private bool RowTilesMatch(int rowIndex)
        {
            return _board.TileAt(rowIndex, 0).CompareSymbol(_board.TileAt(rowIndex, 1)) &&
                   _board.TileAt(rowIndex, 2).CompareSymbol(_board.TileAt(rowIndex, 1));
        }

        private bool IsRowPopulated(int rowIndex)
        {
            return _board.TileAt(rowIndex, 0) != null &&
                   _board.TileAt(rowIndex, 1) != null &&
                   _board.TileAt(rowIndex, 2) != null;
        }
    }
}