using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public UserData userData;
    public UserInfo userInfo;
    string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        userInfo = FindObjectOfType<UserInfo>();
        savePath = Path.Combine(Application.persistentDataPath, "userdata.json");
    }

    private void Start()
    {
        if (!LoadUserData())
        {
            userData = new UserData("Hwang", 100000, 50000);
        }

        userInfo.Refresh();
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
    }

    public bool LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            return true;
        }
        else return false;
    }


    public void Withdrawal(int value)
    {
        
}
