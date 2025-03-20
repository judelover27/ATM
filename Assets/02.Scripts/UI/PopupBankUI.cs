using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopupBankUI : MonoBehaviour
{
    
    public GameObject homeUI;
    public GameObject depositUI;
    public GameObject withdrawalUI;
    public GameObject sendMoneyUI;
    public GameObject backBtn;
    public Button logoutBtn;
    public PopupErrorUI errorUI;

    private IState currentState;

    private HomeState homeState;
    private DepositState depositState;
    private WithdrawState withdrawalState;
    private SendMoneyState sendMoneyState;

    private void Awake()
    {
        homeState = new HomeState(this);
        depositState = new DepositState(this);
        withdrawalState = new WithdrawState(this);
        sendMoneyState = new SendMoneyState(this);
    }

    private void Start()
    {
        logoutBtn.onClick.AddListener(OnLogOut);
        currentState = homeState;
        ChangeState(currentState);
    }

    void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = state;
        currentState.EnterState();
    }

    public void OnClickHome()
    {
        ChangeState(homeState);
    }

    public void OnClickDeposit()
    {
        ChangeState(depositState);
    }

    public void OnClickWithdraw()
    { 
        ChangeState(withdrawalState);
    }

    public void OnClickSendMoney()
    {
        ChangeState(sendMoneyState);
    }

    public void OnLogOut()
    {
        GameManager.Instance.currentUserData = null;
        GameManager.Instance.currentUserID = null;
        UIManager.Instance.OnLogOut();
    }

    public void PopupErrorUI(string text)
    {
        if(errorUI != null)
        {
            errorUI.SetErrorText(text);
        }
    }
}
