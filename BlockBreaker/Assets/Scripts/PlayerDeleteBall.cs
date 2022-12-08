using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDeleteBall : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lifeText; //残機数を記すテキスト

    [SerializeField]
    private GameObject ball;

    private LifeManager lifeManager;

    //ボールが下壁に当たったらボールが消える
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            OpponentDeleteBall.wall_num = 1; //下壁に衝突

            Destroy(collision.gameObject); //ボールを削除

            if (lifeManager.life > 1) //ライフがあったら
            {
                //ballに設定したオブジェクトの生成
                Instantiate(ball);

                lifeManager.life--; //残機数を減らす

                //残機表示の更新
                lifeText.text = $"LIFE : {lifeManager.life}";
            }
            else if (lifeManager.life == 1) //残機数が無くなったら
            {
                //ゲームオーバー画面へ遷移
                SceneManager.LoadScene("GameOver");
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        lifeManager = GameObject.Find("Scripts").GetComponent<LifeManager>();

        //残機表示の初期設定
        lifeText.text = $"LIFE : {lifeManager.life}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
