using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    instance = new GameObject("UIManager").AddComponent<UIManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public PopupBankUI popupBankUI;
    public SignInUI signInUI;
    private IState currentState;

    private SignInState signInState;
    private PopupBankState popupBankState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        popupBankUI = FindObjectOfType<PopupBankUI>(true);
        signInUI = FindObjectOfType<SignInUI>(true);

        popupBankState = new PopupBankState();
        signInState = new SignInState();
    }

    private void Start()
    {
        currentState = signInState;
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

    public void OnSignIn()
    {
        ChangeState(popupBankState);
    }

    public void OnLogOut()
    {
        ChangeState(signInState) ;
    }
}
