using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    #region SingleTon
    private static UserInfo _instance;
    public static UserInfo instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(UserInfo)) as UserInfo;

                GameObject go = new GameObject("UserInfo");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<UserInfo>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public UUID sessionid;
    public string id;
    public string password;
}

public class UUID
{
    public string sessionid;
}
