using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrangement : MonoBehaviour
{
    private GameObject[] Blocks;

    private int onoff; //表示:1/非表示:0を決める

    private bool waitTime; //コルーチンの待ち時間終了否か

    private int[] selectblocks = new int[8];

    // Start is called before the first frame update
    void Start()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Blocks"); //全てのブロックを配列「Block」に格納
        waitTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime == true)
        { 
            //赤にするブロックを選定
            for(int i = 0; i < 7; i++)
            {
                selectblocks[i] = Random.Range(0,64);
            }
            
            //選定されたブロックの色を赤色に変更
            for(int i = 0; i < selectblocks.Length; i++)
            {
                Blocks[selectblocks[i]].GetComponent<Renderer>().material.color = Color.red;
            }

            for (int i = 0; i < Blocks.Length; i++)
            {
                onoff = Random.Range(0, 2); //0:非表示or1:表示

                if (onoff == 0)
                {
                    Blocks[i].SetActive(false); //非表示
                }
                else
                {
                    Blocks[i].SetActive(true); //表示
                }
            }

            waitTime = false;

            //コルーチンの呼び出し
            StartCoroutine("WaitTime");
        }
    }

    //Aの後に2秒待ってBをする
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(10.0f); //待つ時間

        // 待ち時間後にしたいこと

        //選定されたブロックの色を赤色に変更
        for (int i = 0; i < selectblocks.Length; i++)
        {
            Blocks[selectblocks[i]].GetComponent<Renderer>().material.color = Color.white;
        }

        waitTime = true; 

    }
}


