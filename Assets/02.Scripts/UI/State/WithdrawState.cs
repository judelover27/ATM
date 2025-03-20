using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithdrawState : IState
{
    private PopupBankUI popoupBank;

    public WithdrawState(PopupBankUI instance)
    {
        popoupBank = instance;
    }

    public void EnterState()
    {
        popoupBank.homeUI.SetActive(false);
        popoupBank.depositUI.SetActive(false);
        popoupBank.withdrawalUI.SetActive(true);
        popoupBank.sendMoneyUI.SetActive(false);
        popoupBank.backBtn.SetActive(true);
    }

    public void ExitState()
    {
        popoupBank.withdrawalUI.SetActive(false);
        popoupBank.backBtn.SetActive(false);
    }
}
