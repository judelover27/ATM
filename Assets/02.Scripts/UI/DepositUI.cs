using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DepositUI : MonoBehaviour
{
    public TMP_InputField DepositInput;
    public Button DepositBtnInput;
    public Button backBtn;
    public List<TransactionBtnInfo> deposits;



    private void OnEnable()
    {
        foreach (var deposit in deposits)
        {
            deposit.button.onClick.AddListener(() => Deposit(deposit.value));
        }
        DepositBtnInput.onClick.AddListener(OnBtnInput);
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDisable()
    {
        foreach (var deposit in deposits)
        {
            deposit.button.onClick.RemoveAllListeners();
        }

        DepositBtnInput.onClick.RemoveListener(OnBtnInput);
        backBtn.onClick.RemoveListener(OnBackBtnClick);
    }


    void OnBackBtnClick()
    {
        UIManager.Instance.popupBankUI.OnClickHome();
    }


    void OnBtnInput()
    {
        Deposit(InputValue());
    }

    public void Deposit(int value)
    {
        
        if (value > 0)
        {
            if (GameManager.Instance.currentUserData != null)
            {
                UserData userData = GameManager.Instance.currentUserData;
                if (userData.cash > value)
                {
                    userData.balance += value;
                    userData.cash -= value;
                    GameManager.Instance.SaveUserData();
                    GameManager.Instance.userInfo.Refresh();
                }
                else
                {
                    UIManager.Instance.popupBankUI.PopupErrorUI("Cash is not enough!");
                }
            }
        }
        else Debug.Log("0보다 큰 액수를 입력해주세요.");
    }

    int InputValue()
    {
        if (DepositInput != null)
        {
            if (int.TryParse(DepositInput.text, out int value))
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
