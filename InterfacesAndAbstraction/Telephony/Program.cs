using Telephony.Interfaces;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urlAddresses = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ICallable device;
            for (int i = 0; i < phoneNums.Length; i++)
            {
                if(phoneNums[i].Length == 10)
                {
                    device = new Smartphone();
                }
                else// if (phoneNums[i].Length == 7)
                {
                    device = new StationaryPhone();
                }
                try
                {
                    Console.WriteLine(device.Call(phoneNums[i]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            IBrowsable browsable = new Smartphone();
            for (int i = 0; i < urlAddresses.Length; i++)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(urlAddresses[i]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
