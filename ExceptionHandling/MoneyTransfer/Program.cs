string[] bankAccounts = Console.ReadLine().Split(',');
//string bankName = bankAccounts[0];
Dictionary<int, double> bankAccountsDictionary = new Dictionary<int, double>();
for (int i = 0; i < bankAccounts.Length; i++)
{
    string[]  bankAccount = bankAccounts[i].Split('-');
    int bankAccountID = int.Parse(bankAccount[0]);
    double bankAccountBalance = double.Parse(bankAccount[1]);
    bankAccountsDictionary.Add(bankAccountID, bankAccountBalance);
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "End")
    {
        break; 
    }
    string[] tokens = input.Split(' ');
    //Deposit 1 50
    try
    {
        if (tokens[0] == "Deposit")
        {
            int bankAccountID = int.Parse(tokens[1]);
            if (!bankAccountsDictionary.ContainsKey(bankAccountID))
            {
                throw new Exception("Invalid account!");
            }

            double amount = double.Parse(tokens[2]);
            bankAccountsDictionary[bankAccountID] += amount;
        }
        else if (tokens[0] == "Withdraw")
        {
            int bankAccountID = int.Parse(tokens[1]);
            if (!bankAccountsDictionary.ContainsKey(bankAccountID))
            {
                throw new Exception("Invalid account!");
            }

            double amount = double.Parse(tokens[2]);
            if (bankAccountsDictionary[bankAccountID] < amount)
            {
                throw new Exception("Insufficient balance!");
            }

            bankAccountsDictionary[bankAccountID] -= amount;
        }
        else
        {
            throw new Exception("Invalid command!");
        }

        Console.WriteLine($"Account {tokens[1]} has new balance: {bankAccountsDictionary[int.Parse(tokens[1])]:F2}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        //throw;
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}