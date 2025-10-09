namespace Little_Console_Thingies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int cols = 15;
            int rows = 15;
            bool[,] grid = new bool[cols, rows];
            //randomise grid between 0 and 1 (false and true)
            for (int i = 0; i < cols; i++) // loop through each coloumn
            {
                for (int j = 0; j < rows; j++) // loop through each row of the column
                {
                    grid[i, j] = rand.Next(2) == 1;
                }
            }
            

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
