using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class WithdrawUI : MonoBehaviour
{
    public TMP_InputField WithdrawInput;
    public Button WithdrawBtnInput;
    public Button backBtn;
    public List<TransactionBtnInfo> withdraws;




    private void OnEnable()
    {
        foreach (var withdraw in withdraws)
        {
            withdraw.button.onClick.AddListener(() => Withdraw(withdraw.value));
        }

        WithdrawBtnInput.onClick.AddListener(OnBtnInput);
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDisable()
    {
        foreach (var withdraw in withdraws)
        { 
            withdraw.button.onClick.RemoveAllListeners(); 
        }

        WithdrawBtnInput.onClick.RemoveListener(OnBtnInput);
        backBtn.onClick.RemoveListener(OnBackBtnClick);
    }


    void OnBackBtnClick()
    {
        UIManager.Instance.popupBankUI.OnClickHome();
    }


    void OnBtnInput()
    {
        Withdraw(InputValue());
    }

    public void Withdraw(int value)
    {
        if (value > 0)
        {
            if (GameManager.Instance.currentUserData != null)
            {
                UserData userData = GameManager.Instance.currentUserData;
                if (userData.balance > value)
                {
                    userData.balance -= value;
                    userData.cash += value;
                    GameManager.Instance.SaveUserData();
                    GameManager.Instance.userInfo.Refresh();
                }
                else
                {
                    UIManager.Instance.popupBankUI.PopupErrorUI("Deposit is unsufficient!");
                }
            }
        }

        else Debug.Log("0보다 큰 액수를 입력해주세요.");
    }

    int InputValue()
    {
        if (WithdrawInput != null)
        {
            if (int.TryParse(WithdrawInput.text, out int value))
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
