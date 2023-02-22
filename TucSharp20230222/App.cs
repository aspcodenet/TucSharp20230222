public class App
{
    public void Run()
    {
        // KONTO
        // många 

        //var kontoList = new List<Konto>();

        var atm = new Atm();

        var a = new Konto();
        a.AccountNo = "456";
        a.Balance = 100;
        atm.AddAccount(a);
        //atm.kontoList.Add(a);
        //atm.kontoList = null;
        //atm.kontoList.RemoveAll();

        atm.AddAccount(new Konto{ AccountNo = "123", Balance = 1200});
        atm.AddAccount(new Konto { AccountNo = "123", Balance = 14200 });


        while (true)
        {
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Print all accounts");
            int sel = Convert.ToInt32(Console.ReadLine());
            if(sel == 3)
            {
                foreach (var acc in kontoList)
                {
                    Console.WriteLine($"{acc.AccountNo} {acc.Balance} kr");
                }
            }
            if (sel == 1)
            {
                Console.WriteLine("Ange kontonummer:");
                var kontoNr = Console.ReadLine();

                Console.WriteLine("Ange belopp:");
                var belopp = Convert.ToInt32(Console.ReadLine());

                atm.Withdraw(kontoNr, belopp);

            }

        }
    }


}

public class Atm
{
    private List<Konto> kontoList = new List<Konto>();

    public bool AddAccount(Konto account)
    {
        foreach (var acc in kontoList)
        {
            if (acc.AccountNo == account.AccountNo)
            {
                return false;
            }
        }

        kontoList.Add(account);
        return true;
    }

    public void Withdraw(string kontonummer, int belopp)
    {
        foreach (var acc in kontoList)
        {
            if (acc.AccountNo == kontonummer)
            {
                acc.Balance -= belopp;
                return;
            }
        }
    }

    public void Deposit(string kontonnummer, int belopp)
    {

    }
}

public class Konto
{
    public int Balance{ get; set; }
    public string AccountNo{ get; set; }

}