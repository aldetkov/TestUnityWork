using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

namespace TaskWorker
{
    [State(StateKeys.onWayState)]
    public class OnWayState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.onWayState);
            Model.Set("globalButtonEnable", false);
        }

        [One(0)]
        private void SendWorkerToTarget()
        {
            Model.EventManager.Invoke(EventKeys.workerNextPlace);
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set("globalButtonEnable", true);
        }
    }
}
