using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInState : IState
{

    public void EnterState()
    {
        UIManager.Instance.signInUI.gameObject.SetActive(true);
        UIManager.Instance.popupBankUI.gameObject.SetActive(false);
    }

    public void ExitState()
    {
        UIManager.Instance.signInUI.gameObject.SetActive(false);
    }
}
