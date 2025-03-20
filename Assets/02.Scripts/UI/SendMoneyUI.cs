using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class SendMoneyUI : MonoBehaviour
{
    public TMP_InputField recipient;
    public TMP_InputField sendMoneyInput;
    public Button sendMoneyBtn;
    public Button backBtn;

    private void OnEnable()
    {
        sendMoneyBtn.onClick.AddListener(OnBtnInput);
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDisable()
    {

        sendMoneyBtn.onClick.RemoveListener(OnBtnInput);
        backBtn.onClick.RemoveListener(OnBackBtnClick);
    }


    void OnBackBtnClick()
    {
        UIManager.Instance.popupBankUI.OnClickHome();
    }


    void OnBtnInput()
    {
        SendMoney(recipient.text, InputValue());
    }

    public void SendMoney(string id, int value)
    {
        if (GameManager.Instance.currentUserID == id)
        {
            UIManager.Instance.popupBankUI.PopupErrorUI($"You cannot send yourself!");
            return;
        }

        if (!GameManager.Instance.dataBaseDictionay.ContainsKey(id))
        {
            UIManager.Instance.popupBankUI.PopupErrorUI("There is no matched ID.");
            return;
        }

        if (value <= 0)
        {
            UIManager.Instance.popupBankUI.PopupErrorUI("Plese Input more than 0");
            return;
        }

        if (GameManager.Instance.currentUserData != null)
        {
            UserData userData = GameManager.Instance.currentUserData;
            UserData recipientData = GameManager.Instance.dataBaseDictionay[id];

            if (userData.balance > value)
            {
                userData.balance -= value;
                recipientData.balance += value;
                UIManager.Instance.popupBankUI.PopupErrorUI($"{value} is sucessfully sent to {recipientData.userName}!");
                GameManager.Instance.SaveUserData();
                GameManager.Instance.userInfo.Refresh();
            }
            else
            {
                UIManager.Instance.popupBankUI.PopupErrorUI("Deposit is unsufficient!");
            }
        }
    }

    int InputValue()
    {
        if (sendMoneyInput != null)
        {
            if (int.TryParse(sendMoneyInput.text, out int value))
            {
                return value;
            }
            else Debug.Log("숫자를 입력해주세요.");
            return 0;
        }

        Debug.Log("원하는 값을 입력해주세요.");
        return 0;
    }

}

