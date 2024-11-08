using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get{
            if(_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(GameManager)) as GameManager;

                GameObject go = new GameObject("GameManager");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion
    // Start is called before the first frame update
    public character character;
    public Monster monster;
    public int curAttackCnt = 0;
    public bool isFight = false;
    public BackgroundScroll backgroundScroll;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isFight == true)
        {
            if(character.anim.GetCurrentAnimatorStateInfo(0).IsName("character_attack") == true)
            {
                float animTime = character.anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
                float AttackCnt = animTime / 1;

                if((int)AttackCnt > curAttackCnt)
                {
                    curAttackCnt = (int)AttackCnt;
                    AttackMonster();
                }
            }   
        }
    }

    public void AfterCrashCharacterToMonster()
    {
        character.PlayAnimation(character.PlayerState.run);
        monster.SetMonsterSpeed(30f);
        backgroundScroll.SetScrollSpeed(5f);
    }

    public void CrashCharacterToMonster()
    {
        character.PlayAnimation(character.PlayerState.attack);
        monster.SetMonsterSpeed(0);
        backgroundScroll.SetScrollSpeed(0f);
        isFight = true;
        curAttackCnt = 0;
    }
    // 10번 anim.play("attack")를 실행하고, 그 후에는 anim.play("run")을 실행한다.

    public void AttackMonster()
    {
        if(monster.hp > 0)
        {
            monster.hp -= character.attack;
        }
        else
        {
            AfterCrashCharacterToMonster();
        }
    }
}