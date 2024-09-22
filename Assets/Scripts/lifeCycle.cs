using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    public enum StateBtn
    {
        None = 0,
        Btn1 = 1,
        Btn2 = 2,
        Btn3 = 3,
    }

    public StateBtn sBtn = StateBtn.None;
    void Awake()
    {
        Debug.Log(sBtn);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sBtn);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    void TestFunc()
    {

    }
}
