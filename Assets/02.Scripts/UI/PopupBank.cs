using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    private static PopupBank instance;
    public static PopupBank Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PopupBank>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public GameObject homeUI;
    public GameObject depositUI;
    public GameObject withdrawalUI;
    public GameObject backBtn;
    public PopupErrorUI errorUI;

    private IState currentState;

    private HomeState homeState;
    private DepositState depositState;
    private WithdrawState withdrawalState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        homeState = new HomeState(this);
        depositState = new DepositState(this);
        withdrawalState = new WithdrawState(this);
    }

    private void Start()
    {
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

    public void PopupErrorUI(string text)
    {
        if(errorUI != null)
        {
            errorUI.SetErrorText(text);
            errorUI.gameObject.SetActive(true);
        }
    }
}
