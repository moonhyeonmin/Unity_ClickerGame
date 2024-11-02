using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class character : MonoBehaviour
{
    public int attack = 10;
    public Animator anim;
    public enum PlayerState
    {
        none = 0,
        run = 1,
        attack = 2
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy")
        {
            Debug.Log("===Character Trigger start====");
            GameManager.instance.CrashCharacterToMonster(); 
        }
    }

    int cnt = 0;
    public void PlayAnimation(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.none:
                break;
            case PlayerState.run:
                anim.Play("character_run");
                break;
            case PlayerState.attack:
                anim.Play("character_attack");
                cnt += 100;
                break;
        }
    }

     public void SendScore(int score)
    {
        StartCoroutine(SendScoreToServer(score));
    }

    IEnumerator SendScoreToServer(int score)
    {
        string url = CommonDefine.serverURL + "savescore"; // 서버의 API 엔드포인트 설정
        WWWForm form = new WWWForm();
        form.AddField("score", score);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score sent successfully: " + score);
        }
        else
        {
            Debug.LogError("Error sending score: " + www.error);
        }
    } 
}