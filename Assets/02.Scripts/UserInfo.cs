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

    private void Update()
    {

    }

    public void Refresh()
    {
        userName.text = GameManager.Instance.userData.userName;
        InputValue(balance, GameManager.Instance.userData.balance);
        InputValue(cash, GameManager.Instance.userData.cash);
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
