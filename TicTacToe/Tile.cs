namespace TicTacToe
{
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
}