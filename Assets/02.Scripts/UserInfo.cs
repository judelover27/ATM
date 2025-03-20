using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI balance;
    public TextMeshProUGUI cash;

    public void Refresh()
    {
        UserData data = GameManager.Instance.currentUserData;
        if (data != null)
        {
            userName.text = data.userName;
            InputValue(balance, data.balance);
            InputValue(cash, data.cash);
        }
        else Debug.Log($"userdata is null");
    }

    void InputValue(TextMeshProUGUI text,int value)
    {
        text.text = CommaNumber(value);
    }

   string CommaNumber(int value)
    {
        return string.Format($"{value:N0}");
    }

}
