using AxGrid;
using AxGrid.Tools.Binders;

public class BankCoinsAccount
{
    public int Coins { get; private set; }
    public BankAccountName AccountName { get; }

    public BankCoinsAccount(BankAccountName accountName)
    {
        Coins = 0;
        AccountName = accountName;
        Settings.Model.SilentSet(accountName.ToString(), this);
    }

    public void AddCoins(int amountCoins)
    {
        Coins += amountCoins;
        ChangeCoinsModel(amountCoins);
    }

    public void RemoveCoins(int amountCoins)
    {
        Coins -= amountCoins;
        Coins = Coins < 0 ? 0 : Coins;

        ChangeCoinsModel(-amountCoins);
    }

    private void ChangeCoinsModel(int changedAmount)
    {
        Settings.Model.Set(AccountName.ToString(), this);

        var data = new { Balance = $"{Coins}$" };
        Settings.Model.SetString(EventFiled.CoinsBalance.ToString(), "{Balance}", data);

        string changeAmountText = changedAmount >= 0 ? $"+{changedAmount}" : $" -{-changedAmount}";
        Settings.Model.SetString(EventFiled.ChangedCoins.ToString(), changeAmountText);
    }
}