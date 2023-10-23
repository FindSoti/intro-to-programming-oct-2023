using Banking.Domain;



namespace Banking.Tests;
public class MakingWithdrawls
{
    [Fact]
    public void MakingWithdrawalsDecreasesBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 120.23M;



        account.Withdraw(amountToWithdraw);



        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();



        account.Withdraw(openingBalance + .01M);



        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void CanTakeFullBalance()
    {
        var account = new Account();



        account.Withdraw(account.GetBalance());



        Assert.Equal(0, account.GetBalance());
    }
}
