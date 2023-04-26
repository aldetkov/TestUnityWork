using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.homeState)]
    public class HomeState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.homeState);

            Model.EventManager.Invoke(ModelKeys.colorKey, StateKeys.homeState);
        }
    }
}
