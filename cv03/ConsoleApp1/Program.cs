using ConsoleApp1;

class Program
{
    static void Main()
    {
        double[,] values1 = { { 1, 1, 1 }, { 3, 4, 0 }, { 7, 6, 7 } };
        double[,] values2 = { { 5, 6, 4 }, { 7, 2, 5 }, { 9, 5, 11 } };

        Matrix m1 = new Matrix(values1);
        Matrix m2 = new Matrix(values2);

        Console.WriteLine("Součet matic A a B:");
        Console.WriteLine(m1 + m2);
        
       
        Console.WriteLine("Rozdíl matic A a B:");
        Console.WriteLine(m1 - m2);
        

        Console.WriteLine("Násobení matic A a B:");
        Console.WriteLine(m1 * m2);
        

        Console.WriteLine("Jsou matice A a B stejné?");
        Console.WriteLine(m1 == m2);
        Console.WriteLine();

        Console.WriteLine("Jsou matice A a B rozdílné?");
        Console.WriteLine(m1 != m2);
        Console.WriteLine();

        Console.WriteLine("Matice A po použití unárního operátoru:");
        Console.WriteLine(-m1);
        

        Console.WriteLine("Determinant matice A:");
        Console.WriteLine(m1.Determinant());
    }
}