﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositState : IState
{
    private PopupBankUI popoupBank;

    public DepositState(PopupBankUI intance)
    {
        popoupBank = intance;
    }

    public void EnterState()
    {
        popoupBank.homeUI.SetActive(false);
        popoupBank.depositUI.SetActive(true);
        popoupBank.withdrawalUI.SetActive(false);
        popoupBank.sendMoneyUI.SetActive(false);
        popoupBank.backBtn.SetActive(true);
    }

    public void ExitState()
    {
        popoupBank.depositUI.SetActive(false);
        popoupBank.backBtn.SetActive(false);
    }
}


