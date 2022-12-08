using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentBar : MonoBehaviour
{
    private float speed; //バーの動く速さ
    public GameObject ball;

    private bool wait = false; //待ち状態

    private Vector3 initialRight; //右バーの初期状態
    private Vector3 initialLeft; //左バーの初期状態
    private Vector3 initialUp; //上バーの初期状態

    public static bool upBarBall = false;
    public static bool sideBarBall = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("RightBar")) //右バーの場合
        {
            initialRight = transform.position;
        }
        else if (this.gameObject.CompareTag("LeftBar")) //左バーの場合
        {
            initialLeft = transform.position;
        }
        else if (this.gameObject.CompareTag("UpBar")) //上バーの場合
        {
            initialUp = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0.9f; //バーの動く速さ

        ball = GameObject.FindGameObjectWithTag("Ball");

        //本オブジェクトの位置を取得
        Transform myTransform = this.transform;
        //posに取得した位置を格納
        Vector3 pos = myTransform.position;

        if (ball != null) //ボールが表示されていれば
        {
            if (this.gameObject.CompareTag("UpBar")) //上バーの場合
            {
                //pos.xをボールのxと同じにする
                pos.x = ball.transform.position.x;

                if (pos.x <= 21.5 && pos.x >= -17) //バーの動く範囲を制限(壁を突き抜けないように)
                {
                    if (!wait) //待ち状態が終わったら
                    {
                        myTransform.position = Vector3.MoveTowards(myTransform.position, pos, speed); //現在の位置からposに格納される点まで「speed」の速さで移動
                        StartCoroutine("WaitTime"); //数秒待ってから次のボールポジションを追う
                    }

                    if(myTransform.position.x == 0) //バーのx座標が0になったら
                    {
                        upBarBall = true;
                    }
                    else
                    {
                        upBarBall = false;
                    }
                }
            }
            else if(this.gameObject.CompareTag("RightBar") || this.gameObject.CompareTag("LeftBar"))
            {
                //pos.zをボールのzと同じにする
                pos.z = ball.transform.position.z;

                if (pos.z <= 17 && pos.z >= -17.7) //バーの動く範囲を制限(壁を突き抜けないように)
                {
                    if (!wait) //待ち状態が終わったら
                    {
                        myTransform.position = Vector3.MoveTowards(myTransform.position, pos, speed); //現在の位置からposに格納される点まで「speed」の速さで移動
                        StartCoroutine("WaitTime"); //数秒待ってから次のボールポジションを追う
                    }

                    if (initialRight.z == myTransform.position.z || initialLeft.z == myTransform.position.z) //バーのz座標が初期状態のz座標に一致したら
                    {
                        sideBarBall = true;
                    }
                    else
                    {
                        sideBarBall = false;
                    }
                }
            }
        }
    }

    IEnumerator WaitTime()
    {
        // 初めにしたいこと
        wait = true; //待ち状態に入る

        yield return new WaitForSeconds(0.05f); //待つ時間

        // 数秒後にしたいこと
        wait = false; //待ち状態が終わり
    }
}
