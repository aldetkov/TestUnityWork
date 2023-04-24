using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class CardCollectionController : MonoBehaviourExtBind
{
    private const string ON_DRAW_BUTTON_EVENT = "OnDrawButton";
    private const string ON_CARD_BUTTON_EVENT = "OnCardButton";

    #region Mono

    [OnStart]
    private void OnStartThis()
    {
        Settings.Fsm = new();
        Settings.Fsm.Add(new InitState());
        Settings.Fsm.Add(new ReadyState());
        Settings.Fsm.Add(new AddCardState());
        Settings.Fsm.Add(new DropCardState());

        Settings.Fsm.Start(nameof(InitState));
    }

    [OnUpdate]
    private void OnUpdateThis()
    {
        Settings.Fsm.Update(Time.deltaTime);
    }

    [OnRefresh(1f)]
    private void OnRefreshThis()
    {
        StateLog.CurrentState(Settings.Fsm);
    }

    #endregion

    #region Binds

    [Bind]
    private void OnDrawCardClick()
    {
        Settings.Fsm.Invoke(ON_DRAW_BUTTON_EVENT);
    }

    [Bind]
    private void OnCardPrefabChanged()
    {
        CardPrefab cardPrefab = Settings.Model.Get<CardPrefab>(Prefab.CardPrefab.ToString());
        Settings.Fsm.Invoke(ON_CARD_BUTTON_EVENT, cardPrefab);
    }

    #endregion
}
