using System;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Game(8, 8, 10);
            test.DrawBoard();
        }
    }
}
