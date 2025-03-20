using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpUI : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField passwordConfirm;
    public Button signUpBtn;
    public Button back;
    public PopupErrorUI popupError;

    int defaultCash = 100000;
    int defaultBalance = 150000;

    private void Start()
    {
        signUpBtn.onClick.AddListener(OnSignUp);
        back.onClick.AddListener(OnBack);
        gameObject.SetActive(false);
    }
    public void OnSignUp()
    {
        if(id.text == "")
        {
            popupError.SetErrorText("Plese input ID");
            return;
        }

        if (userName.text == "")
        {
            popupError.SetErrorText("Plese input userName");
            return;
        }

        if (GameManager.Instance.dataBaseDictionay.ContainsKey(id.text))
        {
            popupError.SetErrorText("This ID is already taken.");
            return;
        }

        if (!ConfirmPassword())
        {
            return;
        }

        UserData newUserData = new UserData(userName.text, password.text, defaultCash, defaultBalance);
        GameManager.Instance.dataBaseDictionay[id.text] = newUserData;
        GameManager.Instance.SaveUserDatabase();
        OnBack();
        popupError.SetErrorText("You're registered correctly");
    }

    bool ConfirmPassword()
    {
        if (password.text.Length > 6)
        {
            if(password.text != passwordConfirm.text)
            {
                popupError.SetErrorText("Password does not match with Confirm Password!");
                return false;
            }

            return true;
        }

        popupError.SetErrorText("Password must be at least 7 characters long.");
        return false;

    }

    public void OnBack()
    {
        gameObject.SetActive(false);
    }
}
