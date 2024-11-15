using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCounter()
    {
        StartCoroutine(GetCounter());
    }

    public void OnClickSceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator GetCounter()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i); 
            yield return new WaitForSeconds(1);
        }
    }

    public GameObject id;
    public GameObject password;
    public Text responseText; // 메시지를 표시할 UI Text 요소

    public void OnclickLgoinBtn()
    {
        string Strid = id.GetComponent<InputField>().text;
        string Strpwd = password.GetComponent<InputField>().text;

        List<CommonDefine.serverPacket> packetList = new List<CommonDefine.serverPacket>();
        CommonDefine.serverPacket packet = new CommonDefine.serverPacket("userid", Strid);
        CommonDefine.serverPacket packet2 = new CommonDefine.serverPacket("userpwd", Strpwd);

        packetList.Add(packet);
        packetList.Add(packet2);

        // 서버에 로그인 요청 보내기
        StartCoroutine(LoginRequest(Strid, Strpwd));
    }

    IEnumerator LoginRequest(string userId, string userPwd)
    {
        string url = $"http://127.0.0.1:3000/login?userid={UnityWebRequest.EscapeURL(userId)}&userpwd={UnityWebRequest.EscapeURL(userPwd)}";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string response = www.downloadHandler.text;
            Debug.Log("Server response: " + response);

            if (response.Contains("\"yes\""))
            {
                OnClickSceneChange(); // 장면 전환
            }
            else if (response.Contains("\"no\""))
            {
                responseText.text = "아이디, 비밀번호 오류"; // 오류 메시지 출력
            }
            else
            {
                responseText.text = "데이터 비통신"; // 기타 오류 메시지 출력
            }
        }
        else
        {
            Debug.LogError("www error: " + www.error);
          //  responseText.text = "네트워크 오류 발생: " + www.error; // 네트워크 오류 메시지 출력
        }
    }
}
