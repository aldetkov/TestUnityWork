using AxGrid.FSM;
using AxGrid.Model;
using System.Collections.Generic;

namespace CardTask
{
    [State(StateKeys.initState)]
    public class InitState : AbstractState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.userCollection, new List<Card>(10));
            Model.Set(ModelKeys.tableCollection, new List<Card>(15));
        }
    }
}
