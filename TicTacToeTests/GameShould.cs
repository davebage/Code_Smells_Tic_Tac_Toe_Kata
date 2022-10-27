using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
    public class GameShould
    {
        private Game game;

        private const int TopRow = 0;
        private const int MiddleRow = 1;
        private const int BottomRow = 2;

        public GameShould()
        {
           game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            Action wrongPlay = () => game.Play('O', TopRow, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play('X', 0, 0);
            
            Action wrongPlay = () => game.Play('X', MiddleRow, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play('X', 0, 0);

            Action wrongPlay = () => game.Play('O', TopRow, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play('X', TopRow, 0);
            game.Play('O', MiddleRow, 0);

            Action wrongPlay = () => game.Play('X', TopRow, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', TopRow, 0);
            game.Play('O', MiddleRow, 0);
            game.Play('X', TopRow, 1);
            game.Play('O', MiddleRow, 1);
            game.Play('X', TopRow, 2);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', BottomRow, 2);
            game.Play('O', TopRow, 0);
            game.Play('X', MiddleRow, 0);
            game.Play('O', TopRow, 1);
            game.Play('X', MiddleRow, 1);
            game.Play('O', TopRow, 2);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', MiddleRow, 0);
            game.Play('O', TopRow, 0);
            game.Play('X', MiddleRow, 1);
            game.Play('O', TopRow, 1);
            game.Play('X', MiddleRow, 2);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', TopRow, 0);
            game.Play('O', MiddleRow, 0);
            game.Play('X', BottomRow, 0);
            game.Play('O', MiddleRow, 1);
            game.Play('X', BottomRow, 1);
            game.Play('O', MiddleRow, 2);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', BottomRow, 0);
            game.Play('O', TopRow, 0);
            game.Play('X', BottomRow, 1);
            game.Play('O', TopRow, 1);
            game.Play('X', BottomRow, 2);

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', TopRow, 0);
            game.Play('O', BottomRow, 0);
            game.Play('X', MiddleRow, 0);
            game.Play('O', BottomRow, 1);
            game.Play('X', MiddleRow, 1);
            game.Play('O', BottomRow, 2);

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }
    }
}
