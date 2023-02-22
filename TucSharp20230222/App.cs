public class App
{
    public void Run()
    {
        // KONTO
        // många 
        var kontoList = new List<Konto>();
        
        var a = new Konto();
        a.AccountNo = "456";
        a.Balance = 100;
        kontoList.Add(a);

        kontoList.Add(new Konto{ AccountNo = "123", Balance = 1200});


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

                //var konto = Hitta konto med Kontonnummer = kontoNr
                //var acc = kontoList.First(konto => konto.AccountNo == kontoNr);
                foreach (var acc in kontoList)
                {
                    if (acc.AccountNo == kontoNr)
                    {
                        acc.Balance -= belopp;
                    }
                }
            }

        }
    }


}

public class Konto
{
    public int Balance{ get; set; }
    public string AccountNo{ get; set; }

}