using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.homeState)]
    public class HomeState : PlaceState
    {
        protected override void Init()
        {
            bgColorKey = "homeColor";

            placeButton = "homeButton";
        }
    }
}
