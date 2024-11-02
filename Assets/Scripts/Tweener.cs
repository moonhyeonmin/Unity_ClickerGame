using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Tweener4 : MonoBehaviour
{
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        //  img.DOFade(1, 3f).SetLoops(5,LoopType.Yoyo);
        //  img.transform.DOScale(new Vector3(0,0,0),3f).SetLoops(5, LoopType.Restart);
        go.GetComponent<Image>().DOFade(0,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
