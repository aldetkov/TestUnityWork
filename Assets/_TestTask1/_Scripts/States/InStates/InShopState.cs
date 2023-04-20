using AxGrid;
using AxGrid.FSM;
using Random = UnityEngine.Random;

[State(nameof(InShopState))]
public class InShopState : AInState
{
    private static readonly ButtonBind _buttonBind = ButtonBind.ShopButton;

    private const float TIME_PERIOD_REMOVE_COINS = 2f;

    private readonly int _maxCoinsToRemove = 5;

    public InShopState() : base(_buttonBind) { }

    [Loop(TIME_PERIOD_REMOVE_COINS)]
    private void RemoveCoins()
    {
        BankCoinsAccount bankCoinsAccount = Model.Get<BankCoinsAccount>(BankAccountName.JadCoinsBalance.ToString());

        int coinsToRemove = Random.Range(1, _maxCoinsToRemove);

        if (bankCoinsAccount.Coins - coinsToRemove < 0)
        {
            Settings.Model.SetString(EventFiled.ChangedCoins.ToString(), "?");
            return;
        }

        bankCoinsAccount.RemoveCoins(coinsToRemove);
    }
}