using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
    public class GameShould
    {
        private readonly Game game;

        private const int TopRow = 0;
        private const int MiddleRow = 1;
        private const int BottomRow = 2;

        private const int LeftColumn = 0;
        private const int MiddleColumn = 1;
        private const int RightColumn = 2;

        public GameShould()
        {
           game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            var exception = Assert.Throws<Exception>(() => game.Play(Token.O, TopRow, LeftColumn));
            Assert.Equal("Invalid player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play(Token.X, 0, 0);

            var exception = Assert.Throws<Exception>(() => game.Play(Token.X, MiddleRow, LeftColumn));
            Assert.Equal("Invalid player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play(Token.X, 0, 0);

            var exception = Assert.Throws<Exception>(() => game.Play(Token.O, TopRow, LeftColumn));
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(Token.X, TopRow, LeftColumn);
            game.Play(Token.O, MiddleRow, LeftColumn);

            var exception = Assert.Throws<Exception>(() => game.Play(Token.X, TopRow, LeftColumn));
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play(Token.X, TopRow, LeftColumn);
            game.Play(Token.O, MiddleRow, LeftColumn);
            game.Play(Token.X, TopRow, MiddleColumn);
            game.Play(Token.O, MiddleRow, MiddleColumn);
            game.Play(Token.X, TopRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(Token.X, BottomRow, RightColumn);
            game.Play(Token.O, TopRow, LeftColumn);
            game.Play(Token.X, MiddleRow, LeftColumn);
            game.Play(Token.O, TopRow, MiddleColumn);
            game.Play(Token.X, MiddleRow, MiddleColumn);
            game.Play(Token.O, TopRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Token.X, MiddleRow, LeftColumn);
            game.Play(Token.O, TopRow, LeftColumn);
            game.Play(Token.X, MiddleRow, MiddleColumn);
            game.Play(Token.O, TopRow, MiddleColumn);
            game.Play(Token.X, MiddleRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Token.X, TopRow, LeftColumn);
            game.Play(Token.O, MiddleRow, LeftColumn);
            game.Play(Token.X, BottomRow, LeftColumn);
            game.Play(Token.O, MiddleRow, MiddleColumn);
            game.Play(Token.X, BottomRow, MiddleColumn);
            game.Play(Token.O, MiddleRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Token.X, BottomRow, LeftColumn);
            game.Play(Token.O, TopRow, LeftColumn);
            game.Play(Token.X, BottomRow, MiddleColumn);
            game.Play(Token.O, TopRow, MiddleColumn);
            game.Play(Token.X, BottomRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Token.X, TopRow, LeftColumn);
            game.Play(Token.O, BottomRow, LeftColumn);
            game.Play(Token.X, MiddleRow, LeftColumn);
            game.Play(Token.O, BottomRow, MiddleColumn);
            game.Play(Token.X, MiddleRow, MiddleColumn);
            game.Play(Token.O, BottomRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal(Token.O, winner);
        }
    }
}
