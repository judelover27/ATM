using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBankState : IState
{
    public void EnterState()
    {
        UIManager.Instance.signInUI.gameObject.SetActive(false);
        UIManager.Instance.popupBankUI.gameObject.SetActive(true);
    }

    public void ExitState()
    {
        UIManager.Instance.popupBankUI.gameObject.SetActive(false);
    }
}
