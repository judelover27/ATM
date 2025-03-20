using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMoneyState : IState
{
    private PopupBankUI popoupBank;

    public SendMoneyState(PopupBankUI instance)
    {
        popoupBank = instance;
    }

    public void EnterState()
    {
        popoupBank.homeUI.SetActive(false);
        popoupBank.depositUI.SetActive(false);
        popoupBank.withdrawalUI.SetActive(false);
        popoupBank.sendMoneyUI.SetActive(true);
        popoupBank.backBtn.SetActive(true);
    }

    public void ExitState()
    {
        popoupBank.sendMoneyUI.SetActive(false);
        popoupBank.backBtn.SetActive(false);
    }
}