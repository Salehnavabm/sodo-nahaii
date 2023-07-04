using System;

namespace SudokuSolver
{
    class halsodo
    {
        // تعریف کردن گرفتن ماتریس برای کلاس حل سودو

        private int[,] board;
        public int[,] Board
            // اجازه دسترسی
        {
            get { return board; }
            set { board = value; }
        }

        public halsodo()
        {
            // تعریف کردن یک سودوکو دو بعدی 9*9 برای گرفتن ماتریس
            board = new int[9, 9];
        }

        public void GetInput()
        {
            // گرفتن ماتریس 9*9
            Console.WriteLine("Enter the Sudoku puzzle (use 0 for empty cells):");

            for (int i = 0; i < 9; i++)
            {
                string str = Console.ReadLine();
                //این برای اینکه فاصله رو جزو متغیرحساب نکند و قبول کنه
                string[] numbers = str.Split(' ');
                // این تیکه از کد رو خودم نزدم و اخر کار زدم
                if (numbers.Length != 9)
                {
                    throw new FormatException("sodoko ra be soorat sahih vared konid.");
                }

                for (int j = 0; j < 9; j++)
                {
                    if (!int.TryParse(numbers[j], out int value) || value < 0 || value > 9)
                    {
                        throw new FormatException("sodoko ra be soorat sahih vared konid.");
                    }

                    board[i, j] = value;
                }
            }
        }
        // متدی برای چاپ 
        public void Solve()
        {
            if (SolveSudoku())
            {
                Console.WriteLine("Sudoku solved!");

                PrintBoard();
            }
            else
            {
                Console.WriteLine("No solution exists!");
            }
        }
        // متدی برای حل سودوکو با استفاده از الگورینتم بازگشت به عقب
        private bool SolveSudoku()
        {
            int str, sot;

            if (!find(out str, out sot))
            {
                return true;
            }

            for (int num = 1; num <= 9; num++)
            {
                if (IsValidMove(str, sot, num))
                {
                    board[str, sot] = num;

                    if (SolveSudoku())
                    {
                        return true;
                    }

                    board[str, sot] = 0;
                }
            }

            return false;
        }
        // متدی برای پیدا کردن
        private bool find(out int str, out int sot)
        {
            for (str = 0; str < 9; str++)
            {
                for (sot = 0; sot < 9; sot++)
                {
                    if (board[str, sot] == 0)
                    {
                        return true;
                    }
                }
            }

            str = -1;
            sot = -1;
            return false;
        }
        // دونه دونه اعداد رو با استفاده از حلقه فور چک میکنه معتبر هست یا نه
        private bool IsValidMove(int str, int sot, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[str, i] == num || board[i, sot] == num)
                {
                    return false;
                }
            }
            // برسی برای ستون ها و حداول 3*3
            int blockstr = (str / 3) * 3;
            int blocksot = (sot / 3) * 3;

            for (int i = blockstr; i < blockstr + 3; i++)
            {
                for (int j = blocksot; j < blocksot + 3; j++)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        // متدی برای چاپ ماتریس وسودوکو حل شده
        private void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // این به معنای نقطه توقف است ~
        ~halsodo()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

    }
    //ایجاد کلاس جدید برای چاپ
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("adad mored nazar ra vared konid: ");
            Console.WriteLine("1.rahnamaii");
            Console.WriteLine("2.vared kardan sodoco va hal an");
            Console.WriteLine("3.baray khroj 0 ra vared konid:");

            while (true)
            {
                int en = Convert.ToInt32(Console.ReadLine());
                if (en == 1)
                {
                    Console.WriteLine(" 0 0 3 0 2 0 6 0 0 ");
                    Console.WriteLine(" 9 0 0 3 0 5 0 0 1 ");
                    Console.WriteLine(" 0 0 1 8 0 6 4 0 0 ");
                    Console.WriteLine(" 0 0 8 1 0 2 9 0 0 ");
                    Console.WriteLine(" 7 0 0 0 0 0 0 0 8 ");
                    Console.WriteLine(" 0 0 6 7 0 8 2 0 0 ");
                    Console.WriteLine(" 0 0 2 6 0 9 5 0 0 ");
                    Console.WriteLine(" 8 0 0 2 0 3 0 0 9 ");
                    Console.WriteLine(" 0 0 5 0 1 0 3 0 0 ");
                    while (true)
                    {
                        halsodo sudokuSolver = new halsodo();

                        try
                        {
                            sudokuSolver.GetInput();
                            sudokuSolver.Solve();

                            Console.WriteLine();
                            Console.Write("aya mikhay edame bedi?? (0/1)");
                            int ent = Convert.ToInt32(Console.ReadLine());
                            if (ent == 0)
                            {
                                break;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                }
                if (en == 2)
                {
                    while (true)
                    {
                        halsodo sudokuSolver = new halsodo();
                        try
                        {
                            sudokuSolver.GetInput();
                            sudokuSolver.Solve();

                            Console.WriteLine();
                            Console.Write("aya mikhay edame bedi?? (0/1)");
                            int ent = Convert.ToInt32(Console.ReadLine());

                            if (ent == 0)
                            {
                                break;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                }

                if (en == 0)
                {
                    break;
                }
                else
                {
                    Console.Write("adad 1 ya 2 ya 0 ra vared koonid: ");
                }
            }
        }
    }
}


