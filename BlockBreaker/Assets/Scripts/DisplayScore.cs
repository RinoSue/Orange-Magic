using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    private ScoreManager scoreManager;

    [SerializeField]
    private TextMeshProUGUI scoreText1; //スコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI scoreText2; //スコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI scoreText3; //スコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI scoreText4; //スコアを記すテキスト

    public static int[] totalscore = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Scripts").GetComponent<ScoreManager>();

        //スコア表示の初期設定
        scoreText1.text = $"You : {scoreManager.score1}";
        //スコア表示の初期設定
        scoreText2.text = $"Ponta : {scoreManager.score2}";
        //スコア表示の初期設定
        scoreText3.text = $"Gonta : {scoreManager.score3}";
        //スコア表示の初期設定
        scoreText4.text = $"Zonta : {scoreManager.score4}";
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.scorechange == true) //スコアがチェンジしたら
        {
            if (Ball.bar_num == 1)
            {
                //スコア表示の更新
                scoreText1.text = $"You : {scoreManager.score1}";
                scoreManager.scorechange = false;
            }
            else if (Ball.bar_num == 2) //スコアがチェンジしたら
            {
                //スコア表示の更新
                scoreText2.text = $"Ponta : {scoreManager.score2}";
                scoreManager.scorechange = false;
            }
            else if (Ball.bar_num == 3) //スコアがチェンジしたら
            {
                //スコア表示の更新
                scoreText3.text = $"Gonta : {scoreManager.score3}";
                scoreManager.scorechange = false;
            }
            else if (Ball.bar_num == 4) //スコアがチェンジしたら
            {
                //スコア表示の更新
                scoreText4.text = $"Zonta : {scoreManager.score4}";
                scoreManager.scorechange = false;
            }
        }
        
        totalscore[0] = scoreManager.score1;
        totalscore[1] = scoreManager.score2;
        totalscore[2] = scoreManager.score3;
        totalscore[3] = scoreManager.score4;
    }

    //ScoreResultのシーンで使えるようにゲッターを作成
    public static int[] getScore()
    {
        return totalscore;
    }
}
