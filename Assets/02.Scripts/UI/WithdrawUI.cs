using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawUI : MonoBehaviour
{
    public Button WithdrawBtn0;
    public Button WithdrawBtn1;
    public Button WithdrawBtn2;
    public TMP_InputField WithdrawInput;
    public Button WithdrawBtnInput;
    public Button backBtn;



    private void OnEnable()
    {
        WithdrawBtn0.onClick.AddListener(OnBtn0);
        WithdrawBtn1.onClick.AddListener(OnBtn1);
        WithdrawBtn2.onClick.AddListener(OnBtn2);
        WithdrawBtnInput.onClick.AddListener(OnBtnInput);
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDisable()
    {
        WithdrawBtn0.onClick.RemoveListener(OnBtn0);
        WithdrawBtn1.onClick.RemoveListener(OnBtn1);
        WithdrawBtn2.onClick.RemoveListener(OnBtn2);
        WithdrawBtnInput.onClick.RemoveListener(OnBtnInput);
        backBtn.onClick.RemoveListener(OnBackBtnClick);
    }


    void OnBackBtnClick()
    {
        PopupBank.Instance.OnClickHome();
    }

    void OnBtn0()
    {
        Withdraw(10000);
    }
    void OnBtn1()
    {
        Withdraw(30000);
    }

    void OnBtn2()
    {
        Withdraw(50000);
    }

    void OnBtnInput()
    {
        Withdraw(InputWithdraw());
    }

    public void Withdraw(int value)
    {
        if (value > 0)
        {
            if (GameManager.Instance.userData != null)
            {
                UserData userData = GameManager.Instance.userData;
                if (userData.balance > value)
                {
                    userData.balance -= value;
                    userData.cash += value;
                    GameManager.Instance.SaveUserData();
                    GameManager.Instance.userInfo.Refresh();
                }
                else
                {
                    PopupBank.Instance.PopupErrorUI("Deposit is unsufficient!");
                }
            }
        }
    
        else Debug.Log("0보다 큰 액수를 입력해주세요.");
    }

    int InputWithdraw()
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
