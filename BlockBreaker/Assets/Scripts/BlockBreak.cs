using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    //private ScoreManager scoreManager;

    private void OnCollisionEnter(Collision collision) //ボールがブロックにぶつかったら
    {
        if(this.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            ScoreManager.addscore = 30; //赤ブロックはスコアが30点

        }
        else if(this.gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            ScoreManager.addscore = 10; //白ブロックはスコアが10点
        }

        this.gameObject.SetActive(false); //ブロックを削除
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreManager = GameObject.Find("Scripts").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
