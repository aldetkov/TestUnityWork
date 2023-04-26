using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.storeState)]
    public class StoreState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.storeState);

            Model.EventManager.Invoke(ModelKeys.colorKey, StateKeys.storeState);
        }

        [Loop(1f)]
        private void LoopThis()
        {
            Model.Dec(ModelKeys.cash, 1);
        }
    }
}
