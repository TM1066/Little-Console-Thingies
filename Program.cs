namespace Little_Console_Thingies
{

    public class Particle()
    {
        public bool floats;
        public bool isLiquid;

        public float weight;

    }


    internal class Program
    {
        static public Random rand = new Random();

        static public int cols = 50;
        static public int rows = 150;
        static public Particle?[,] grid = new Particle?[cols, rows];

        static int playerRow = 70;
        static int playerCol = 10;

        static void Main(string[] args)
        {
            //randomise grid between 0 and 1 (false and true)
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    if (rand.Next(2) == 1)
                    {
                        grid[i, j] = null;
                    }
                    else
                    {
                        grid[i, j] = new Particle();
                        grid[i, j].floats = rand.Next(2) == 1;
                        grid[i, j].isLiquid = rand.Next(2) == 1;
                    }
                }
            }

            int generation = 0;

            while (true)
            {
                Console.SetCursorPosition(0,0);
                DisplayGrid(grid);
                Console.Write($"\n\nFrame: {generation}");
                generation++;
                Thread.Sleep(200);
                FallingSand(grid);
                //FallingSandWithPlayer(grid);
                //Conwaysingit(grid);
            }
        }

        // static void RandomiseGrid(Particle?[,] grid)
        // {
        //     //randomise grid between 0 and 1 (false and true)
        //     for (int i = 0; i < cols; i++) // loop through each coloumn
        //     {
        //         if (rand.Next(2) == 1)
        //         {
        //             grid[i,j] = null;
        //         }
        //         if (grid[i, j] != null)
        //         {
        //             grid[i, j].floats = rand.Next(2) == 1;
        //         }
        //     }
        // }

        static void FallingSand(Particle?[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    if (grid[i, j] != null)
                    {
                        //Logic for gas
                        if (grid[i, j].floats)
                        {
                            if (i - 1 >= 0)
                            {
                                //Checking straight up
                                if (grid[i - 1, j] == null)
                                {
                                    grid[i - 1, j] = grid[i, j];
                                    grid[i, j] = null;
                                }
                                else if (!grid[i - 1, j].floats)
                                {
                                    var temp = grid[i - 1, j];
                                    grid[i - 1, j] = grid[i, j];
                                    grid[i, j] = temp;
                                }
                                if (j - 1 >= 0)
                                {
                                    //checking left
                                    if (grid[i, j - 1] == null && rand.Next(2) == 1)
                                    {
                                        grid[i, j - 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    //checking up and left
                                    if (grid[i - 1, j - 1] == null)
                                    {
                                        grid[i - 1, j - 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    else if (!grid[i - 1, j - 1].floats)
                                    {
                                        var temp = grid[i - 1, j - 1];
                                        grid[i - 1, j - 1] = grid[i, j];
                                        grid[i, j] = temp;
                                    }
                                }
                                if (j + 1 < rows)
                                {
                                    //checking right
                                    if (grid[i, j + 1] == null)
                                    {
                                        grid[i, j + 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    //checking up and right
                                    if (grid[i - 1, j + 1] == null)
                                    {
                                        grid[i - 1, j + 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    else if (!grid[i - 1, j + 1].floats)
                                    {
                                        var temp = grid[i - 1, j + 1];
                                        grid[i - 1, j + 1] = grid[i, j];
                                        grid[i, j] = temp;
                                    }
                                }
                            }
                        }
                        //logic for water
                        else if (grid[i, j].isLiquid)
                        {
                            if (i + 1 < cols)
                            {
                                //Checking straight down
                                if (grid[i + 1, j] == null)
                                {
                                    grid[i + 1, j] = grid[i, j];
                                    grid[i, j] = null;
                                }
                                // else if (!grid[i + 1, j].floats && !grid[i + 1, j].isLiquid)
                                // {
                                //     var temp = grid[i + 1, j];
                                //     grid[i + 1, j] = grid[i, j];
                                //     grid[i, j] = temp;
                                // }
                                if (j - 1 >= 0)
                                {
                                    //checking left
                                    if (grid[i, j - 1] == null && rand.Next(2) == 1)
                                    {
                                        grid[i, j - 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    //checking down and left
                                    if (grid[i + 1, j - 1] == null)
                                    {
                                        grid[i + 1, j - 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    // else if (!grid[i + 1, j - 1].floats && !grid[i + 1, j].isLiquid)
                                    // {
                                    //     var temp = grid[i + 1, j - 1];
                                    //     grid[i + 1, j - 1] = grid[i, j];
                                    //     grid[i, j] = temp;
                                    // }
                                }
                                if (j + 1 < rows)
                                {
                                    //checking right
                                    if (grid[i, j + 1] == null)
                                    {
                                        grid[i, j + 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    //checking down and right
                                    if (grid[i + 1, j + 1] == null)
                                    {
                                        grid[i + 1, j + 1] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    // else if (!grid[i + 1, j + 1].floats && !grid[i + 1, j].isLiquid)
                                    // {
                                    //     var temp = grid[i + 1, j + 1];
                                    //     grid[i + 1, j + 1] = grid[i, j];
                                    //     grid[i, j] = temp;
                                    // }
                                }
                            }
                        }
                        //Logic for Sand
                        else
                        {
                            if (i + 1 < cols)
                            {
                                if (grid[i, j] != null)
                                {
                                    //Checking straight Down
                                    if (grid[i + 1, j] == null)
                                    {
                                        grid[i + 1, j] = grid[i, j];
                                        grid[i, j] = null;
                                    }
                                    else if (grid[i + 1, j].isLiquid)
                                    {
                                        var temp = grid[i + 1, j];
                                        grid[i + 1, j] = grid[i, j];
                                        grid[i, j] = temp;
                                    }
                                    if (j - 1 >= 0)
                                    {
                                        //checking down and left
                                        if (grid[i + 1, j - 1] == null && rand.Next(2) == 1)
                                        {
                                            grid[i + 1, j - 1] = grid[i, j];
                                            grid[i, j] = null;

                                        }
                                        else if (grid[i + 1, j - 1] != null)
                                        {
                                            if (grid[i + 1, j - 1].isLiquid && rand.Next(2) == 1)
                                            {
                                                var temp = grid[i + 1, j - 1];
                                                grid[i + 1, j - 1] = grid[i, j];
                                                grid[i, j] = temp;
                                            }
                                        }
                                    }
                                    if (j + 1 < rows)
                                    {
                                        //checking down and right
                                        if (grid[i + 1, j + 1] == null && rand.Next(2) == 1)
                                        {
                                            grid[i + 1, j + 1] = grid[i, j];
                                            grid[i, j] = null;
                                        }
                                        else if (grid[i + 1, j + 1] != null)
                                        {
                                            if (grid[i + 1, j + 1].isLiquid && rand.Next(2) == 1)
                                            {
                                                var temp = grid[i + 1, j + 1];
                                                grid[i + 1, j + 1] = grid[i, j];
                                                grid[i, j] = temp;
                                            }
                                        }  
                                    }
                                }
                            }
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

        static void DisplayGrid(Particle?[,] grid)
        {
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    if (grid[i, j] != null)
                    {
                        if (grid[i, j].floats)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("'");
                        }
                        else if (grid[i, j].isLiquid)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("o");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("—");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(); // go down by a line
            }
        }
    }
}
