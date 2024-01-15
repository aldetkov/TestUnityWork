using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.workState)]
    public class WorkState : PlaceState
    {
        protected override void Init()
        {
            bgColorKey = "workColor";

            placeButton = "workButton";

            OnPlaceAction += ()=> Model.Inc(ModelKeys.cash, 1);
        }
    }
}
