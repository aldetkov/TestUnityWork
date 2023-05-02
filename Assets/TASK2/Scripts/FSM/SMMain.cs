using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;

namespace CardTask
{
    public class SMMain : MonoBehaviourExtBind
    {
        private string fieldName = "userCollect";
        [OnAwake]
        private void AwakeThis()
        {
            Settings.Fsm = new FSM();

            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new OnDrawState());
            Settings.Fsm.Add(new OnTranslateState());
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

        [OnRefresh(1)]
        private void Test()
        {

        }

    }
}
