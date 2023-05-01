using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

namespace TaskWorker
{
    [State(StateKeys.initState)]
    public class InitState : FSMState
    {
        private const int defaultCashCount = 100;

        [Enter]
        private void EnterThis()
        {
            Settings.Model.EventManager.Invoke(EventKeys.workerToStartPos);

            Model.Set(ModelKeys.cash, defaultCashCount);
        }

        [Bind("OnBtn")]
        private void NextPlace(string btnName)
        {
            Model.Set(ModelKeys.targetState, btnName);

            Parent.Change(StateKeys.onWayState);
        }
    }
}
