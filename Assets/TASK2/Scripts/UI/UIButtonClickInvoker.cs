using AxGrid;
using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

namespace CardTask
{
	[RequireComponent(typeof(Button))]
	public class UIButtonClickInvoker: MonoBehaviourExtBind
	{
		[SerializeField] protected string buttonName = "";
		
		protected Button button;

		[OnAwake]
		private void AwakeThis()
		{
			button = GetComponent<Button>();
			if (string.IsNullOrEmpty(buttonName))
			{
				buttonName = name;
				Log.Warn($"Button name is empty {button.name}");
			}
			
			button.onClick.AddListener(InvokeEvent);
		}

		[OnDestroy]
		private void DestroyThis()
		{
			button.onClick.RemoveAllListeners();
		}

		protected virtual void InvokeEvent()
		{
			Settings.Fsm.Invoke("btnClick", buttonName);
			Model.EventManager.Invoke($"On{buttonName}Click");
		}
	}
}