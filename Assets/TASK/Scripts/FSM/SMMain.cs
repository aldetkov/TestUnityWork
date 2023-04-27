using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    public class SMMain : MonoBehaviourExtBind
    {
        [OnAwake]
        private void AwakeThis()
        {
            Settings.Fsm = new FSM();

            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new OnWayState());
            Settings.Fsm.Add(new StoreState());
            Settings.Fsm.Add(new WorkState());
            Settings.Fsm.Add(new HomeState());
        }

        [OnStart]
        private void StartThis()
        {
            Settings.Fsm.Start(StateKeys.initState);
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}
