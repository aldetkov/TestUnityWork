using AxGrid;
using AxGrid.FSM;

public static class StateLog
{
    public static void ExitState(FSM fsm)
    {
        Log.Debug($"Exit {fsm.CurrentStateName}");
    }

    public static void EnterState(FSM fsm)
    {
        Log.Debug($"Enter {fsm.CurrentStateName}");
    }

    public static void CurrentState(FSM fsm)
    {
        Log.Debug($"Current State: {fsm.CurrentStateName}");
    }
}
