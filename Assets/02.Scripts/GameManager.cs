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
    public UserDatabase userDatabase;
    public Dictionary<string, UserData> dataBaseDictionay;
    public UserData currentUserData;
    public string currentUserID;
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

        userInfo = FindObjectOfType<UserInfo>(true);
        savePath = Path.Combine(Application.persistentDataPath, "userDatabase.json");
        dataBaseDictionay = new Dictionary<string, UserData>();
        LoadUserDatabase();
    }

    private void Start()
    {
    }

    void UserDataBaseListToDictionary()
    {
        foreach (var user in userDatabase.users)
        {
            dataBaseDictionay[user.id] = user.userData;
        }
    }

    void UserDataBaseDictionaryToList()
    {
        userDatabase.users.Clear();

        foreach (var dictionary in dataBaseDictionay)
        {
            userDatabase.users.Add(new UserPair(dictionary.Key, dictionary.Value));
        }
    }

    public void SaveUserDatabase()
    {
        UserDataBaseDictionaryToList();
        string json = JsonUtility.ToJson(userDatabase, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadUserDatabase()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userDatabase = JsonUtility.FromJson<UserDatabase>(json);
        }
        else
        {
            userDatabase = new UserDatabase();
        }

        UserDataBaseListToDictionary();

    }

    public void SetCurrentUserData(UserData data)
    {
        currentUserData = data;
        userInfo.Refresh();
    }

    public UserData GetUserData(string id)
    {
        if (dataBaseDictionay.ContainsKey(id))
        {
            return dataBaseDictionay[id];
        }
        return null;
    }

    public void SaveUserData()
    {
        if (currentUserData != null)
        {
            dataBaseDictionay[currentUserID] = currentUserData;
            SaveUserDatabase();
        }
    }
}
