using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class UserDatabase
{
    public List<UserPair> users = new List<UserPair>(); // Dictionary 대신 List 사용 dictionary 직렬화 불가능!
}


[System.Serializable]
public class UserPair// Dictionary의 Key-Value 쌍 저장
{
    public string id; 
    public UserData userData; 

    public UserPair(string id, UserData userData)
    {
        this.id = id;
        this.userData = userData;
    }
}

[System.Serializable]
public class UserData
{
    public string userName;
    public string password;
    public int cash;
    public int balance;

    public UserData(string name,string password , int cash, int balance)
    {
        userName = name;
        this.password = password;
        this.cash = cash;
        this.balance = balance;
    }
}
