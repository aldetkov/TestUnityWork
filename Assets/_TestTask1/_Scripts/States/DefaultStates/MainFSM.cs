using AxGrid;
using AxGrid.Base;
using UnityEngine;

public class MainFSM : MonoBehaviourExtBind
{

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        Settings.Fsm = new();
        Settings.Fsm.Add(new InitState());
        Settings.Fsm.Add(new ReadyState());

        Settings.Fsm.Add(new MoveToWorkState());
        Settings.Fsm.Add(new MoveToShopState());
        Settings.Fsm.Add(new MoveToHomeState());

        Settings.Fsm.Add(new InHomeState());
        Settings.Fsm.Add(new InWorkState());
        Settings.Fsm.Add(new InShopState());
    }

    [OnStart]
    private void OnStartThis()
    {
        Settings.Fsm.Start(nameof(InitState));
    }

    [OnUpdate]
    private void OnUpdateThis()
    {
        Settings.Fsm.Update(Time.deltaTime);
    }

    #endregion
}
