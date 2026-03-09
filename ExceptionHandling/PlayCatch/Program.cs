int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
int excepionsCount = 0;
while (excepionsCount < 3)
{
    string[] input = Console.ReadLine().Split();
    try
    {
        if (input[0] == "Replace")
        {
            int index = int.Parse(input[1]);
            int element = int.Parse(input[2]);
            numbers[index] = element;
            //int temp = numbers[e1];
            //numbers[e1] = numbers[e2];
            //numbers[e2] = temp;
        }
        else if (input[0] == "Print")
        {
            int i1 = int.Parse(input[1]);
            int i2 = int.Parse(input[2]);
            List<int> toPrint = new List<int>();
            for (int i = i1; i <= i2; i++)
            {
                //Console.Write(i + ", ");
                toPrint.Add(numbers[i]);
            }
            Console.WriteLine(string.Join(", ", toPrint));
        }
        else if (input[0] == "Show")
        {
            int index = int.Parse(input[1]);
            Console.WriteLine(numbers[index]);
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        excepionsCount++;
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        excepionsCount++;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        //throw;
        excepionsCount++;
    }
}
Console.WriteLine(string.Join(", ", numbers));