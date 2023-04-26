using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.onWayState)]
    public class OnWayState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.onWayState);

            Model.Set(ModelKeys.enabledButton, false);
        }

        [One(0)]
        private void SendWorkerToTarget()
        {
            Model.EventManager.Invoke(EventKeys.workerNextPlace, Model.GetString(ModelKeys.targetState));
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set(ModelKeys.enabledButton, true);
        }
    }
}
