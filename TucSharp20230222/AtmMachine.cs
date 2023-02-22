public class AtmMachine
{

    public Dictionary<string,int> konton = new Dictionary<string,int>();

    public AtmWithdrawalStatus Withdraw(string accountNumber, int belopp)
    {
        if (!konton.ContainsKey(accountNumber))
            return AtmWithdrawalStatus.AccountMissing;
        if (belopp > 3000) 
            return AtmWithdrawalStatus.MoreThanMaxWithdrawal;
        if(belopp > konton[accountNumber])
            return AtmWithdrawalStatus.NotEnoughBalance;
        
        konton[accountNumber] -= belopp;
        
        return AtmWithdrawalStatus.Ok;
    }

    public int GetBalance(string accountNumber)
    {
        return konton[accountNumber];
    }  // => TryGetBalance

        
}

public enum AtmWithdrawalStatus
{
    Ok,
    AccountMissing,
    MoreThanMaxWithdrawal,
    //Max per dag?
    NotEnoughBalance

}