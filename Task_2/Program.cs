using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        WriteLine("Enter the number of rows ");
        int row = Convert.ToInt32(ReadLine());
        WriteLine("Enter the nuber of cols");
        int col = Convert.ToInt32(ReadLine());
        Random r = new Random();
        // так как сложение матриц с разными по числу строками и столбцами не возможно то я сделал сразу три матрицы из одной пары введеннных данных
        var Matrix1 = new int[row, col];
        var Matrix2 = new int[row, col];
        var SumMatrix = new int[row, col];
        WriteLine("Matrix 1:");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Matrix1[i, j] = r.Next(10);
                Write($"{Matrix1[i, j],3} ");
            }
            WriteLine();
        }
        WriteLine("Matrix 2:");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Matrix2[i, j] = r.Next(10);
                Write($"{Matrix2[i, j],3} ");
            }
            WriteLine();
        }
        WriteLine("Sum of 1 and 2:");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                SumMatrix[i, j] = Matrix1[i, j] + Matrix2[i, j];
                Write($"{SumMatrix[i, j],3} ");
            }
            WriteLine();
        }
    }
}