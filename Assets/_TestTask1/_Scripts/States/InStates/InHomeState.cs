using AxGrid.FSM;

[State(nameof(InHomeState))]
public class InHomeState : AInState
{
    private static readonly ButtonBind _buttonBind = ButtonBind.HomeButton;

    public InHomeState() : base(_buttonBind) { }
}
