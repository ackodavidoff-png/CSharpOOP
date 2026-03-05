namespace SquareRoot;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //int num =  int.Parse(Console.ReadLine());
        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new Exception("Invalid number.");
            }

            Console.WriteLine(Math.Sqrt(num));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //throw;
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }
}