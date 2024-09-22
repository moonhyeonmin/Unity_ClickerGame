using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public enum StateBtn
    {
        None = 0,
        Btn1 = 1,
        Btn2 = 2,
        Btn3 = 3,
    }

    public StateBtn sBtn = StateBtn.None;
    // Start is called before the first frame update
    void Start()
    {
        sBtn = StateBtn.None;
    }

    // Update is called once per frame
    void Update()
    {
        switch (sBtn)
        {
            case StateBtn.None:
            {
                Debug.Log("None");
            } break;

            case StateBtn.Btn1:
            {
                Debug.Log("Btn1");
            } break;

            case StateBtn.Btn2:
            {
                Debug.Log("Btn2");
            } break;

            case StateBtn.Btn3:
            {
                Debug.Log("Btn3");
            } break;
        }
    }

    public void OnClickBtn1()
    {
        sBtn = StateBtn.Btn1;
    }

    public void OnClickBtn2()
    {
        sBtn = StateBtn.Btn2;
    }

    public void OnClickBtn3()
    {
        sBtn = StateBtn.Btn3;
    }
}
