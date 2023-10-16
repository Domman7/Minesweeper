using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Game
    {
        private int _height;
        private int _width;
        private int _minesNumber;
        private int[,] _board;
        private bool[,] _opened;

        public Game(int height, int width, int minesNumber)
        {
            _height = height;
            _width = width;
            _minesNumber = minesNumber;
            _board = new int[_height, _width];
            _opened = new bool[_height, _width];

            Random rnd = new Random();
            for (int i = 0; i < _minesNumber; i++)
            {
                _board[rnd.Next(0, _height), rnd.Next(0, _width)] = -1;
            }

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_board[i, j] != -1)
                    {
                        int count = 0;
                        for (int ik = i - 1; ik <= i + 1; ik++)
                        {
                            for (int jk = j - 1; jk <= j + 1; jk++)
                            {
                                if (IsValid(ik, jk) && _board[ik, jk] == -1)
                                {
                                    count++;
                                }
                            }
                            _board[i, j] = count;
                        }
                    }
                    _opened[i, j] = false;
                }
            }
        }

        public void OpenCell(int i, int j)
        {
            _opened[i, j] = true;

        }

        public void OpenRound(int i, int j)
        {
            for (int ik = i - 1; ik <= i + 1; ik++)
            {
                for (int jk = j - 1; jk <= j + 1; jk++)
                {

                    if (IsValid(ik, jk))
                    {
                        _opened[ik, jk] = true;
                    }
                }
            }
        }

        public bool IsValid(int i, int j)
        {

            return i >= 0 && j >= 0 && i < _height && j < _width;
        }

        public void DrawBoard()
        {
            StringBuilder fullLine = new StringBuilder();
            StringBuilder partLine = new StringBuilder();
            StringBuilder numberLine = new StringBuilder();

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++) 
                {
                    if(i == 0)
                    {
                        fullLine.Append("#######");
                        partLine.Append("#     #");
                    }

                    numberLine.Append(GetNumberCell(i, j));
                }
                Console.WriteLine(fullLine);
                Console.WriteLine(partLine);
                Console.WriteLine(numberLine);
                Console.WriteLine(partLine);
                numberLine.Clear();
            }
            Console.WriteLine(fullLine);
        }

        public string GetNumberCell(int i, int j)
        {
            if(!_opened[i, j] || _board[i, j] < 1)
            {
                return "#     #";
            }

            return "#  " + _board[i, j] + "  #";
        }

        public void ShowBoard()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
