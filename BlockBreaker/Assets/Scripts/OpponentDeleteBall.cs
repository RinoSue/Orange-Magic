using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDeleteBall : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private bool delete; //ボールが(Opponentの)壁に当たったかの判定

    public static int wall_num; //ボールが消えた壁(1:下,2:左,3:上,4:右)

    //ボールが壁に当たったらボールが消える
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (this.gameObject.CompareTag("LeftWall")) //左の壁に衝突
            {
                wall_num = 2;
            }
            else if (this.gameObject.CompareTag("UpWall")) //上の壁に衝突
            {
                wall_num = 3;
            }
            else if (this.gameObject.CompareTag("RightWall")) //右の壁に衝突
            {
                wall_num = 4;
            }

            Destroy(collision.gameObject); //ボールを削除

            //ballに設定したオブジェクトの生成(ボールの再出現)
            Instantiate(ball);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        wall_num = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
