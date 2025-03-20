using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignInUI : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPassword;
    public Button SignInBtn;
    public Button SignUpBtn;
    public SignUpUI SignUpUI;
    public PopupErrorUI popupError;

    private void Start()
    {
        SignInBtn.onClick.AddListener(OnSignInBtn);
        SignUpBtn.onClick.AddListener(OnSignUpBtn);
    }

    public void OnSignInBtn()
    {
        UserData currentUserData;
        currentUserData = MatchID(inputID.text);
        if (currentUserData != null )
        {
            if(VerifyPassword(inputPassword.text,currentUserData.password))
            {
                GameManager.Instance.SetCurrentUserData(currentUserData);
                GameManager.Instance.currentUserID = inputID.text;
                UIManager.Instance.OnSignIn();
            }
            else
            {
                popupError.SetErrorText("Password is wrong!");
            }
        }
        else popupError.SetErrorText("ID does not exist!");
    }

    public void OnSignUpBtn()
    {
        SignUpUI.gameObject.SetActive(true);
    }

    public UserData MatchID(string id)
    {
        return GameManager.Instance.GetUserData(id);
    }

    public bool VerifyPassword(string inputPassword,string userPassword)
    {
        return userPassword == inputPassword;
    }
}
