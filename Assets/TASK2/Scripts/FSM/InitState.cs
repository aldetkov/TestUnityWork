using AxGrid.FSM;
using AxGrid.Model;
using System.Collections.Generic;

namespace CardTask
{
    [State(StateKeys.initState)]
    public class InitState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.userCollection, new List<Card>());
            Model.Set(ModelKeys.tableCollection, new List<Card>());
        }

        [Bind(ToolsKeys.btnClickKey)]
        private void OnDrawButtonClick()
        {
            Parent.Change(StateKeys.OnDrawState);
        }
    }
}
