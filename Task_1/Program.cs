using static System.Console;
class Program
{
    static void Main(string[] args) 
    {
        WriteLine("Enter the number of rows ");
        int row = Convert.ToInt32 (ReadLine());
        WriteLine("Enter the nuber of cols");
        int col = Convert.ToInt32 (ReadLine());
        Random r = new Random();
        int sum=0;
        var Matrix = new int[row, col];
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                Matrix[i, j] = r.Next(10);
                sum+=Matrix[i, j];
                Write($"{Matrix[i, j]} ");
            }
            WriteLine();
        }
        WriteLine(sum);
    }
}