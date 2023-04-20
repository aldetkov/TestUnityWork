using AxGrid.FSM;

[State(nameof(InitState))]
public class InitState : FSMState
{
    #region States

    [Enter]
    private void EnterThis()
    {
        InitialzeBankAccount();
        Helper.ChangeViewState();
    }

    [One(0f)]
    private void ChangeState()
    {
        Parent.Change(nameof(ReadyState));
    }

    #endregion

    private void InitialzeBankAccount()
    {
        _ = new BankCoinsAccount(BankAccountName.JadCoinsBalance);
    }
}
