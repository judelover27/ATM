using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithdrawState : IState
{
    private PopupBank popoupBank;

    public WithdrawState(PopupBank instance)
    {
        popoupBank = instance;
    }

    public void EnterState()
    {
        popoupBank.homeUI.SetActive(false);
        popoupBank.depositUI.SetActive(false);
        popoupBank.withdrawalUI.SetActive(true);
        popoupBank.backBtn.SetActive(true);
    }

    public void ExitState()
    {
        popoupBank.withdrawalUI.SetActive(false);
        popoupBank.backBtn.SetActive(false);
    }
}
