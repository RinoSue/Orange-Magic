using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed; //ボールの速さ

    public static Rigidbody rb;

    public static int bar_num; //バーの識別

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed =17f;

        if (OpponentDeleteBall.wall_num == 1) //下壁に衝突後
        {
            if (Input.GetButtonDown("Jump") && rb.velocity == Vector3.zero) //スペースを押す & ボールが静止していたら
            {
                rb.AddForce(new Vector3(-0.7f, 0f, 0.7f) * speed, ForceMode.VelocityChange); //右上にボールを発射
                bar_num = 1;
            }
        }
        else if (OpponentDeleteBall.wall_num == 2) //左壁に衝突後
        {
            if (rb.velocity == Vector3.zero && OpponentBar.sideBarBall == true)
            {
                rb.AddForce(new Vector3(0.7f, 0f, 0.7f) * speed, ForceMode.VelocityChange); //右下にボールを発射
                bar_num = 2;
            }
        }
        else if(OpponentDeleteBall.wall_num == 3) //上壁に衝突後
            {
            if (rb.velocity == Vector3.zero && OpponentBar.upBarBall == true)
            {
                rb.AddForce(new Vector3(-0.7f, 0f, -0.7f) * speed, ForceMode.VelocityChange); //左下にボールを発射
                bar_num = 3;
            }
        }
        else if(OpponentDeleteBall.wall_num == 4) //右壁に衝突後
        {
            if (rb.velocity == Vector3.zero && OpponentBar.sideBarBall == true)
            {
                rb.AddForce(new Vector3(-0.7f, 0f, -0.7f) * speed, ForceMode.VelocityChange); //左上にボールを発射
                bar_num = 4;
            }
        }

        //水平方向の動きが小さくなったら修正する
        if (Mathf.Abs(rb.velocity.x) > 18.0f)
        {
            Vector3 v = rb.velocity;
            v.x = 17.0f;
            rb.velocity = v;
        }


        //水平方向の動きが小さくなったら修正する
        if (Mathf.Abs(rb.velocity.x) < -18.0f)
        {
            Vector3 v = rb.velocity;
            v.x = -17.0f;
            rb.velocity = v;
        }

        //垂直方向の動きが小さくなったら修正する
        if (Mathf.Abs(rb.velocity.z) > 18.0f)
        {
            Vector3 v = rb.velocity;
            v.z = 17.0f;
            rb.velocity = v;
        }

        //垂直方向の動きが小さくなったら修正する
        if (Mathf.Abs(rb.velocity.z) < -18.0f)
        {
            Vector3 v = rb.velocity;
            v.z = -17.0f;
            rb.velocity = v;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("speedItem")) //スピードアイテムに衝突したら
        {
            speed *= 1.3f; //ボールのスピードを30%加速
            Destroy(collision.gameObject); //スピードアイテムを削除
        }
        */

        if (collision.gameObject.CompareTag("RightBar"))
        {
            bar_num = 4;
        }
        else if (collision.gameObject.CompareTag("LeftBar")) //左バーの場合
        {
            bar_num = 2;
        }
        else if (collision.gameObject.CompareTag("UpBar")) //上バーの場合
        {
            bar_num = 3;
        }
        else if (collision.gameObject.CompareTag("PlayerBar"))
        {
            bar_num = 1;
        }
        

        //水平方向の動きが小さくなったら修正する
        if (Mathf.Abs(rb.velocity.x) < 15)
        {
            Vector3 v = rb.velocity;
            v.x *= 15;
            rb.velocity = v;
        }

        //垂直方向の動きが小さくなったら修正する
        if(Mathf.Abs(rb.velocity.z) < 15)
        {
            Vector3 v = rb.velocity;
            v.z *= 15;
            rb.velocity = v;
        }
    }

}
