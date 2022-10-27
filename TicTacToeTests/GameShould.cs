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
            var exception = Assert.Throws<Exception>(() => game.Play('O', TopRow, LeftColumn));
            Assert.Equal("Invalid player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play('X', 0, 0);

            var exception = Assert.Throws<Exception>(() => game.Play('X', MiddleRow, LeftColumn));
            Assert.Equal("Invalid player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play('X', 0, 0);

            var exception = Assert.Throws<Exception>(() => game.Play('O', TopRow, LeftColumn));
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play('X', TopRow, LeftColumn);
            game.Play('O', MiddleRow, LeftColumn);

            var exception = Assert.Throws<Exception>(() => game.Play('X', TopRow, LeftColumn));
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', TopRow, LeftColumn);
            game.Play('O', MiddleRow, LeftColumn);
            game.Play('X', TopRow, MiddleColumn);
            game.Play('O', MiddleRow, MiddleColumn);
            game.Play('X', TopRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', BottomRow, RightColumn);
            game.Play('O', TopRow, LeftColumn);
            game.Play('X', MiddleRow, LeftColumn);
            game.Play('O', TopRow, MiddleColumn);
            game.Play('X', MiddleRow, MiddleColumn);
            game.Play('O', TopRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', MiddleRow, LeftColumn);
            game.Play('O', TopRow, LeftColumn);
            game.Play('X', MiddleRow, MiddleColumn);
            game.Play('O', TopRow, MiddleColumn);
            game.Play('X', MiddleRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', TopRow, LeftColumn);
            game.Play('O', MiddleRow, LeftColumn);
            game.Play('X', BottomRow, LeftColumn);
            game.Play('O', MiddleRow, MiddleColumn);
            game.Play('X', BottomRow, MiddleColumn);
            game.Play('O', MiddleRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', BottomRow, LeftColumn);
            game.Play('O', TopRow, LeftColumn);
            game.Play('X', BottomRow, MiddleColumn);
            game.Play('O', TopRow, MiddleColumn);
            game.Play('X', BottomRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', TopRow, LeftColumn);
            game.Play('O', BottomRow, LeftColumn);
            game.Play('X', MiddleRow, LeftColumn);
            game.Play('O', BottomRow, MiddleColumn);
            game.Play('X', MiddleRow, MiddleColumn);
            game.Play('O', BottomRow, RightColumn);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }
    }
}
