using AxGrid.FSM;
using UnityEngine;

[State(nameof(InWorkState))]
public class InWorkState : AInState
{
    private const float TIME_PERIOD_ADD_COINS = 2f;

    private readonly int _maxCoinsToAdd = 10;

    private static ButtonBind _buttonBind = ButtonBind.WorkButton;

    public InWorkState() : base(_buttonBind) { }

    [Loop(TIME_PERIOD_ADD_COINS)]
    private void AddCoins()
    {
        BankCoinsAccount bankCoinsAccount = Model.Get<BankCoinsAccount>(BankAccountName.JadCoinsBalance.ToString());

        bankCoinsAccount.AddCoins(Random.Range(1, _maxCoinsToAdd));
    }
}