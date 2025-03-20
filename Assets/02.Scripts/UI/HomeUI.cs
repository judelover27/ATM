using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    public Button depositBtn;
    public Button withdrawBtn;

    private void OnEnable()
    {
        depositBtn.onClick.AddListener(OndepositBtnClick);
        withdrawBtn.onClick.AddListener(OnWithdrawBtnClick);
    }

    private void OnDisable()
    {
        depositBtn.onClick.RemoveListener(OndepositBtnClick);
        withdrawBtn.onClick.RemoveListener(OnWithdrawBtnClick);
    }


    void OndepositBtnClick()
    {
        PopupBank.Instance.OnClickDeposit();
    }

    void OnWithdrawBtnClick()
    {
        PopupBank.Instance.OnClickWithdraw();
    }
}

