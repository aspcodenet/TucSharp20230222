public class App
{
    public void Run()
    {
        var atm = new Atm();

        var a = new Konto();
        a.AccountNo = "456";
        a.Balance = 100;
        atm.AddAccount(a);


        if (atm.AddAccount(new Konto { AccountNo = "123", Balance = 1200 }) == false)
        {
            
        }

        if (atm.AddAccount(new Konto { AccountNo = "123", Balance = 14200 }))
        {
            //Loop 
        }


        while (true)
        {
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Print all accounts");
            int sel = Convert.ToInt32(Console.ReadLine());
            //if(sel == 3)
            //{
            //    foreach (var acc in kontoList)
            //    {
            //        Console.WriteLine($"{acc.AccountNo} {acc.Balance} kr");
            //    }
            //}
            if (sel == 1)
            {
                Console.WriteLine("Ange kontonummer:");
                var kontoNr = Console.ReadLine();

                Console.WriteLine("Ange belopp:");
                var belopp = Convert.ToInt32(Console.ReadLine());

                var status = atm.Withdraw(kontoNr, belopp);
                if (status == Atm.WithdrawStatus.MaxBelopp3000)
                    Console.WriteLine("Du får max ta ut 3000");
                else if (status == Atm.WithdrawStatus.NotEnoughBalance)
                    Console.WriteLine("Du har inte så mycket på kontot");
                else if (status == Atm.WithdrawStatus.InvalidAccount)
                    Console.WriteLine("Felaktigt konto");
                else if (status == Atm.WithdrawStatus.Ok)
                    Console.WriteLine("Uttaget registrerat");
 
            }

        }
    }


}



public class Atm
{

    public enum WithdrawStatus
    {
        MaxBelopp3000,
        NotEnoughBalance,
        InvalidAccount,
        Ok
    }

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

    public WithdrawStatus Withdraw(string kontonummer, int belopp)
    {
        if (belopp > 3000) return WithdrawStatus.MaxBelopp3000;

        foreach (var acc in kontoList)
        {
            if (acc.AccountNo == kontonummer)
            {
                if (acc.Balance < belopp)
                    return WithdrawStatus.NotEnoughBalance;
                acc.Balance -= belopp;
                return WithdrawStatus.Ok;
            }
        }

        return WithdrawStatus.InvalidAccount;
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