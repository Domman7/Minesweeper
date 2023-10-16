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
        private bool _end;
        private int[,] _board;
        private bool[,] _opened;

        private int _curI;
        private int _curJ;

        public Game(int height, int width, int minesNumber)
        {
            _height = height;
            _width = width;
            _minesNumber = minesNumber;
            _end = false;
            _board = new int[_height, _width];
            _opened = new bool[_height, _width];


            _curI = 0;
            _curJ = 0;

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
            if (_board[i, j] == -1)
            {
                _end = true;
            }
            else
            {
                if (!_opened[i, j])
                {
                    _opened[i, j] = true;
                    if (_board[i, j] == 0)
                    {
                        OpenRound(i, j);
                    }

                    DrawBoard();
                }
            }
        }

        public void OpenCell()
        {
            if (_board[_curI, _curJ] == -1)
            {
                _end = true;
            }
            else
            {
                if (!_opened[_curI, _curJ])
                {
                    _opened[_curI, _curJ] = true;
                    if (_board[_curI, _curJ] == 0)
                    {
                        OpenRound(_curI, _curJ);
                    }

                    DrawBoard();
                }
            }
        }

        public void OpenRound(int i, int j)
        {
            for (int ik = i - 1; ik <= i + 1; ik++)
            {
                for (int jk = j - 1; jk <= j + 1; jk++)
                {
                    if (IsValid(ik, jk) && !_opened[ik, jk])
                    {
                        _opened[ik, jk] = true;
                        if (_board[ik, jk] == 0)
                        {
                            OpenRound(ik, jk);
                        }
                    }
                }
            }
        }

        public bool IsValid(int i, int j)
        {

            return i >= 0 && j >= 0 && i < _height && j < _width;
        }

        public bool CheckForEnd()
        {
            return _end;
        }

        public void DrawBoard()
        {
            Console.Clear();
            StringBuilder fullLine = new StringBuilder();
            StringBuilder partLine = new StringBuilder();
            StringBuilder curLine = new StringBuilder();
            StringBuilder numberLine = new StringBuilder();

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (i == 0)
                    {
                        fullLine.Append("######");
                        partLine.Append("#     ");
                        if (j == _width - 1)
                        {
                            fullLine.Append("#");
                            partLine.Append("#");
                        }
                    }

                    if (_curI == i && _curJ == j)
                    {
                        curLine.Append("# ___ ");
                    }
                    else
                    {
                        curLine.Append("#     ");
                    }

                    numberLine.Append(GetNumberCell(i, j));
                }

                Console.WriteLine(fullLine);
                Console.WriteLine(partLine);
                Console.WriteLine(numberLine.Append("#"));
                Console.WriteLine(curLine.Append("#"));
                numberLine.Clear();
                curLine.Clear();
            }
            Console.WriteLine(fullLine);
        }

        public string GetNumberCell(int i, int j)
        {
            if (!_opened[i, j] || _board[i, j] == -1)
            {
                return "#     ";
            }

            return "#  " + _board[i, j] + "  ";
        }

        public void MoveCur(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (IsValid(_curI - 1, _curJ))
                        {
                            _curI--;
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (IsValid(_curI + 1, _curJ))
                        {
                            _curI++;
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (IsValid(_curI, _curJ + 1))
                        {
                            _curJ++;
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (IsValid(_curI, _curJ - 1))
                        {
                            _curJ--;
                        }
                        break;
                    }
            }
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
