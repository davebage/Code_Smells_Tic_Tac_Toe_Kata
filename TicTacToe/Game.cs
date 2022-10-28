using System;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class Game
    {
        private Token _lastSymbol = Token.O;
        private readonly Board _board = new Board();

        public void Play(Token symbol, Coordinate coordinate)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid player");
            }

            if (_board.TileAt(coordinate) != null)
            {
                throw new Exception("Invalid position");
            }

            _lastSymbol = symbol;
            _board.AddTileAt(symbol, coordinate);

        }

        public void Play(Token symbol, int row, int column)
        {
            Play(symbol, new Coordinate(row, column));
        }

        public Token? Winner()
        {
            var index = 0;
            Tile tile = null;
            while (tile == null && index < 3)
            {
                if (_board.CheckHorizontalWin(new Coordinate(index, 0)))
                    tile = _board.TileAt(new Coordinate(index, 0));
                index++;
            }

            if (tile == null) return null;


            return tile.GetToken();
        }
    }
}