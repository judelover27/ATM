using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DepositUI : MonoBehaviour
{
    public Button DepositBtn0;
    public Button DepositBtn1;
    public Button DepositBtn2;
    public TMP_InputField DepositInput;
    public Button DepositBtnInput;
    public Button backBtn;



    private void OnEnable()
    {
        DepositBtn0.onClick.AddListener(OnBtn0);
        DepositBtn1.onClick.AddListener(OnBtn1);
        DepositBtn2.onClick.AddListener(OnBtn2);
        DepositBtnInput.onClick.AddListener(OnBtnInput);
        backBtn.onClick.AddListener(OnBackBtnClick);
    }

    private void OnDisable()
    {
        DepositBtn0.onClick.RemoveListener(OnBtn0);
        DepositBtn1.onClick.RemoveListener(OnBtn1);
        DepositBtn2.onClick.RemoveListener(OnBtn2);
        DepositBtnInput.onClick.RemoveListener(OnBtnInput);
        backBtn.onClick.RemoveListener(OnBackBtnClick);
    }


    void OnBackBtnClick()
    {
        PopupBank.Instance.OnClickHome();
    }

    void OnBtn0()
    {
        Deposit(10000);
    }
    void OnBtn1()
    {
        Deposit(30000);
    }

    void OnBtn2()
    {
        Deposit(50000);
    }

    void OnBtnInput()
    {
        Deposit(InputDeposit());
    }

    public void Deposit(int value)
    {
        
        if (value > 0)
        {
            if (GameManager.Instance.userData != null)
            {
                UserData userData = GameManager.Instance.userData;
                if (userData.cash > value)
                {
                    userData.balance += value;
                    userData.cash -= value;
                    GameManager.Instance.SaveUserData();
                    GameManager.Instance.userInfo.Refresh();
                }
                else
                {
                    PopupBank.Instance.PopupErrorUI("Cash is not enough!");
                }
            }
        }
        else Debug.Log("0보다 큰 액수를 입력해주세요.");
    }

    int InputDeposit()
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
