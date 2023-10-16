using System;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Game(8, 8, 10);
            
            while(true)
            {
                test.DrawBoard();
                int i = int.Parse(Console.ReadLine());
                int j = int.Parse(Console.ReadLine());
                test.OpenCell(i, j);
            }
        }
    }
}
