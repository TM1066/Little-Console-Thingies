namespace Little_Console_Thingies
{
    internal class Program
    {
        static public Random rand = new Random();
        
        static public int cols = 20;
        static public int rows = 140;
        static public bool[,] grid = new bool[cols, rows];

        static int playerRow = 70;
        static int playerCol = 10;

        static void Main(string[] args)
        {
            int spawned = 0;
            //randomise grid between 0 and 1 (false and true)
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    if (spawned <= 25)
                    {
                        grid[i, j] = rand.Next(2) == 1;
                    }
                    else
                    {
                        grid[i, j] = false;
                    }

                }
            }

            int generation = 0;

            while (true)
            {
                Console.Clear();
                DisplayGrid(grid);
                Console.Write($"\n\nFrame: {generation}");
                generation++;
                Thread.Sleep(200);
                FallingSand(grid);
                //FallingSandWithPlayer(grid);
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
                        //Checking straight below sand
                        if (grid[i, j] && !grid[i - 1, j])
                        {
                            grid[i, j] = false;
                            grid[i - 1, j] = true;
                        }
                        if (j - 1 >= 0)
                        {
                            //checking down and left
                            if (grid[i, j] && !grid[i - 1, j - 1])
                            {
                                grid[i, j] = false;
                                grid[i - 1, j - 1] = true;
                            }
                        }
                        if (j + 1 < rows)
                        {
                            //checking down and right
                            if (grid[i, j] && !grid[i - 1, j + 1])
                            {
                                grid[i, j] = false;
                                grid[i - 1, j + 1] = true;
                            }
                        }
                        
                    }
                }
            }
        }

        static void FallingSandWithPlayer(bool[,] grid)
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
            grid[playerCol, playerRow] = true;
        }
        
        static void Conwaysingit(bool[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    int neighbours = 0;

                    if (j - 1 >= 0) // checking below
                    {
                        if (grid[i, j - 1]) { neighbours++; }
                    }
                    if (j - 1 >= 0 & i - 1 >= 0) // checking down and left
                    {
                        if (grid[i - 1, j - 1]) { neighbours++; }
                    }
                    if (j - 1 >= 0 & i + 1 < cols) // checking down and right
                    {
                        if (grid[i + 1, j - 1]) { neighbours++; }
                    }
                    if (j + 1 < rows) //checking above
                    {
                        if (grid[i, j + 1]) { neighbours++; }
                    }
                    if (j + 1 < rows & i - 1 >= 0) // checking up and left
                    {
                        if (grid[i - 1, j + 1]) { neighbours++; }
                    }
                    if (j + 1 < rows & i + 1 < cols) // checking up and right
                    {
                        if (grid[i + 1, j + 1]) { neighbours++; }
                    }

                    if (i - 1 >= 0) // checking left
                    {
                        if (grid[i - 1, j]) { neighbours++; }
                    }
                    if (i + 1 < cols) // checking right
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
