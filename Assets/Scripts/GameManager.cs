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
    public BackgroundScroll backgroundScroll;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrashCharacterToMonster()
    {
        character.PlayAnimation(character.PlayerState.attack);
        monster.SetMonsterSpeed(0);
        backgroundScroll.SetScrollSpeed(0f);

    }
}