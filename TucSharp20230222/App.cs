using Microsoft.VisualBasic.CompilerServices;

class Employee
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string AccountNo { get; set; }

    public virtual int CalculateSalary()
    {
        return 0;
    }
}
class HourlyEmplyoee : Employee
{
    public int HourlySalary { get; set; }
    public int HoursWorked { get; set; }
    public override int CalculateSalary()
    {
        return HourlySalary * HoursWorked;
    }
}

class MonthlyEmplyoee : Employee
{
    public int MonthlySalary { get; set; }
    public override int CalculateSalary()
    {
        return MonthlySalary;
    }
}



public class Point
{
    public int XPos { get; set; }
    public int YPos { get; set; }

    public Point(int x, int y)
    {
        //Console.WriteLine("aaa");
        XPos = x;
        YPos = y;
    }
}

public class Shape
{
    public Point Point { get; set; }


    public Shape(Point point)
    {
        Point = point;
    }

    public virtual void Draw()
    {

    }
}


public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle(Point p,int radius)
        :base(p)
    {
        Radius = radius;
    }

    public override void Draw()
    {
       Console.WriteLine($"Ritar Circle på {base.Point.XPos}  {base.Point.YPos} ");
    }
}

public class App
{
    public void Run()
    {
        var p = new Point(100,12);
        var shape = new Shape(p);

        var circle = new Circle( new Point(4,2), 10);

        var listShapes = new List<Shape>();
        listShapes.Add(shape);
        listShapes.Add(circle);

        foreach (var s in listShapes)
        {
            s.Draw();
        }


        var stefan = new MonthlyEmplyoee
        {
            AccountNo="123",
            BirthDate = new DateTime(1972,8,3),
            MonthlySalary = 15000,
            Name = "Stefan"
        };
        var oliver = new HourlyEmplyoee
        {
            AccountNo = "123231",
            BirthDate = new DateTime(2008, 5, 28),
            HourlySalary = 20,
            HoursWorked = 20,
            Name = "Oliver"
        };

        var list = new List<Employee>();
        list.Add(stefan);
        list.Add(oliver);

        foreach (var emp in list)
        {
            int salary = emp.CalculateSalary();
            Console.WriteLine( $"{emp.Name} - {salary}");
        }


        int c = 12;
        Console.WriteLine($"{c}");
        Test(ref c);
        Console.WriteLine($"{c}");

        int gissning;
        while (true)
        {
            Console.Write("Ange en siffra");
            string s = Console.ReadLine();
            if (int.TryParse(s, out gissning) == false)
            {
                Console.WriteLine("Ange ett tal, tack");
                continue;
            }
            
            
        }
        Console.WriteLine($"Du gissade {gissning} ");






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
                {
                    //int newBalance = atm.GetBalance(kontoNr);
                    Console.WriteLine("Uttaget registrerat");
                    //Console.WriteLine($"New balance is:{newBalance}");
                }

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