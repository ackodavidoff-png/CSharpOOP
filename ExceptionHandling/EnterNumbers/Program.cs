namespace EnterNumbers;

class Program
{
    static void Main(string[] args)
    {
        int start = 1;
        int end = 100;
        List<int> nums = new List<int>();
        while (nums.Count < 10)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num <= start || num >= end)
                {
                    throw new Exception($"Your number is not in range {start} - 100!");
                    //throw new Exception($"Your number is not in range 0 - 100!");
                }

                nums.Add(num);
                start = num;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
        Console.WriteLine(string.Join(", ",  nums));
    }
}