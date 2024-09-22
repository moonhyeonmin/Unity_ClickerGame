using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
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

    public void PlayAnimation(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.none:
                break;
            case PlayerState.run:
                break;
            case PlayerState.attack:
                anim.Play("character_attack");
                break;
        }
    }
}
