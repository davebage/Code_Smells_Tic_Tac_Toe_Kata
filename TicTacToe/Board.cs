using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private const int WinningTokenCount = 3;
        private readonly List<Tile> _plays = new List<Tile>();

        public Tile TileAt(Coordinate coordinate)
        {
            return _plays.FirstOrDefault(tile => tile.CompareCoordinate(coordinate));
        }

        public Tile TileAt(int row, int column)
        {
            return TileAt(new Coordinate(row, column));
        }

        public void AddTileAt(Token symbol, Coordinate coordinate)
        {
            _plays.Add(new Tile(symbol, coordinate));
        }

        public bool CheckHorizontalWin(Coordinate coordinate)
        {
            return _plays.Count(tile => tile.CompareRow(coordinate)) == WinningTokenCount;
        }
    }
}