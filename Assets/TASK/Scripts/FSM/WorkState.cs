using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State(StateKeys.workState)]
    public class WorkState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.workState);

            Model.EventManager.Invoke(ModelKeys.colorKey, StateKeys.workState);
        }

        [Loop(1f)]
        private void LoopThis()
        {
            Model.Inc(ModelKeys.cash, 1);
        }
    }
}
