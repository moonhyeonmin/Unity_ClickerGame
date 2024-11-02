using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserSession : MonoBehaviour
{
    public static UserSession Instance { get; private set; }
    public string SessionID { get; private set; }
    public string UserID { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSessionData(string sessionId, string userId)
    {
        SessionID = sessionId;
        UserID = userId;
    }
}