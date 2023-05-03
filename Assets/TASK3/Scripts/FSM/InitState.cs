using AxGrid.FSM;
using AxGrid.Model;

[State("Init")]
public class InitState : FSMState
{
    [Bind("btnClick")]
    private void OnLobbyButtonClick()
    {
        Parent.Change("OutLobby");
    }
}
