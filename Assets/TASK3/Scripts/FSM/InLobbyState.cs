using AxGrid.FSM;
using AxGrid.Model;

[State("InLobby")]
public class InLobbyState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Model.EventManager.Invoke("IsGame", true);
    }

    [Exit]
    private void ExitThis()
    {
        Model.EventManager.Invoke("IsGame", false);
    }

    [Bind("btnClick")]
    private void OnExit()
    {
        Parent.Change("Init");
    }
}
