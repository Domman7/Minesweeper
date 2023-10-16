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
                if (test.CheckForEnd())
                {
                    Console.WriteLine("Вы проиграли!");
                    break;
                }
                else
                {
                    test.DrawBoard();
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            {
                                test.OpenCell();
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                test.MoveCur(ConsoleKey.UpArrow);
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                test.MoveCur(ConsoleKey.DownArrow);
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                test.MoveCur(ConsoleKey.RightArrow);
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                test.MoveCur(ConsoleKey.LeftArrow);
                                break;
                            }
                    }
                }
            }
        }
    }
}
