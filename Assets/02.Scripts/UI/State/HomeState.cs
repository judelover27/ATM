using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeState : IState
{
    private PopupBank popoupBank;

    public HomeState(PopupBank instance)
    {
        popoupBank = instance;
    }

    public void EnterState()
    {
        popoupBank.homeUI.SetActive(true);
        popoupBank.depositUI.SetActive(false);
        popoupBank.withdrawalUI.SetActive(false);
        popoupBank.backBtn.SetActive(false);
    }

    public void ExitState()
    {
        popoupBank.homeUI.SetActive(false);
        popoupBank.backBtn.SetActive(true);
    }
}

