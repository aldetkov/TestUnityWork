using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace CardTask
{
    public class UIButtonBindInteractable : UIButtonClickInvoker
    {
        [SerializeField] protected bool defaultEnable = true;
		
        protected string BtnEnableField => $"Btn{buttonName}Enable";
		
        [OnStart]
        [Bind("OnBtn{buttonName}EnableChanged")]
        protected void OnItemEnable()
        {
            if (button.interactable != Model.GetBool(BtnEnableField, defaultEnable))
                button.interactable = Model.GetBool(BtnEnableField, defaultEnable);
        }
    }
}