using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMMain : MonoBehaviourExtBind
{
    [OnAwake]
    private void AwakeThis()
    {
        Settings.Fsm = new FSM();

        Settings.Fsm.Add(new InitState());
        Settings.Fsm.Add(new OutLobbyState());
        Settings.Fsm.Add(new InLobbyState());
    }

    [OnStart]
    private void StartThis()
    {
        Settings.Fsm.Start("Init");
    }
}
