using AxGrid.FSM;
using AxGrid.Model;

[State("OutLobby")]
public class OutLobbyState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Model.EventManager.Invoke("TextFieldIn");
    }

    [Exit]
    private void ExitThis()
    {
        Model.EventManager.Invoke("TextFieldOut");
    }

    [Bind("TFieldEnd")]
    private void OnUserEnterLogin(string fieldName, string value)
    {
        if (fieldName == "UserLogin" && value != "")
        {
            Model.Set("UserID", value);
            SetNewUser(value);

            Parent.Change("InLobby");
        }
    }

    private void SetNewUser(string value)
    {
        var allUsers = Model.GetString("UsersInLobby");

        string newUser = allUsers == null ? value : allUsers + "\n" + value;

        Model.SetString("UsersInLobby", newUser);
    }
}
