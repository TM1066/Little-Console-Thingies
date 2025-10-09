namespace Little_Console_Thingies
{
    internal class Program
    {
        static public Random rand = new Random();
        
        static public int cols = 25;
        static public int rows = 100;
        static public bool[,] grid = new bool[cols, rows];
        static void Main(string[] args)
        {
            //randomise grid between 0 and 1 (false and true)
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    grid[i, j] = rand.Next(2) == 1;
                }
            }

            while (true)
            {
                Console.Clear();
                DisplayGrid(grid);
                Thread.Sleep(200);
                FallingSand(grid);
                //Conwaysingit(grid);
            }
        }

        static void RandomiseGrid(bool[,] grid)
        {
            //randomise grid between 0 and 1 (false and true)
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    grid[i, j] = rand.Next(2) == 1;
                }
            }
        }

        static void FallingSand(bool[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    if (i - 1 >= 0)
                    {
                        if (grid[i, j] && !grid[i - 1, j])
                        {
                            grid[i, j] = false;
                            grid[i - 1, j] = true;
                        }
                    }
                }
            }
        }
        
        static void Conwaysingit(bool[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    int neighbours = 0;

                    if (j - 1 >= 0)
                    {
                        if (grid[i, j - 1]) { neighbours++; }
                    }
                    if (j + 1 < rows)
                    {
                        if (grid[i, j + 1]) { neighbours++; }
                    }

                    if (i - 1 >= 0)
                    {
                        if (grid[i - 1, j]) { neighbours++; }
                    }
                    if (i + 1 < cols)
                    {
                        if (grid[i + 1, j]) { neighbours++; }
                    }

                    if ((neighbours < 2 || neighbours > 3) && grid[i, j])
                    {
                        grid[i, j] = false;
                    }
                    if (neighbours == 3)
                    {
                        grid[i, j] = true;
                    }
                }
            }
        }
        
        static void DisplayGrid(bool[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    // if place in grid is true write a character else write a space
                    Console.Write(grid[i, j] == false ? 'O' : ' ');
                }

                Console.WriteLine(); // go down by a line
            }
        }
    }
}
