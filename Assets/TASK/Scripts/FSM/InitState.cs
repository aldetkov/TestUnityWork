using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
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
    }
}
