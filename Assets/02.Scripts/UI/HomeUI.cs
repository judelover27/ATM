using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    public Button depositBtn;
    public Button withdrawBtn;
    public Button sendMoneyBtn;

    private void OnEnable()
    {
        depositBtn.onClick.AddListener(OndepositBtnClick);
        withdrawBtn.onClick.AddListener(OnWithdrawBtnClick);
        sendMoneyBtn.onClick.AddListener(OnSendMoneyClick);
    }

    private void OnDisable()
    {
        depositBtn.onClick.RemoveListener(OndepositBtnClick);
        withdrawBtn.onClick.RemoveListener(OnWithdrawBtnClick);
        sendMoneyBtn.onClick.RemoveListener(OnSendMoneyClick);
    }


    void OndepositBtnClick()
    {
        UIManager.Instance.popupBankUI.OnClickDeposit();
    }

    void OnWithdrawBtnClick()
    {
        UIManager.Instance.popupBankUI.OnClickWithdraw();
    }

    void OnSendMoneyClick()
    {
        UIManager.Instance.popupBankUI.OnClickSendMoney();
    }
}

