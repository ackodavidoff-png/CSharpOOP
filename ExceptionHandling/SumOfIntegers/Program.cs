namespace SumOfIntegers;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        List<int> nums = new List<int>();
        foreach (string num in input)
        {
            try
            {
                int n = int.Parse(num);
                nums.Add(n);
            }
            catch (FormatException)
            {
                Console.WriteLine(@$"The element '{num}' is in wrong format!");
            }
            catch (OverflowException)
            {
                Console.WriteLine(@$"The element '{num}' is out of range!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            finally
            {
                Console.WriteLine(@$"Element '{num}' processed - current sum: {nums.Sum()}");
            }
        }
        Console.WriteLine($"The total sum of all integers is: {nums.Sum()}");
    }
}