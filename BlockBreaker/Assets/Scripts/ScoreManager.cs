using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int addscore;
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public bool scorechange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score1);

        if (addscore > 0) //加点があったら
        {
            if (Ball.bar_num == 1) //下バーの点数なら
            {
                score1 = score1 + addscore; //下バーのトータルスコアに加算

                scorechange = true;
            }
            else if(Ball.bar_num == 2) //左バーの点数なら
            {
                score2 = score2 + addscore; //左バーのトータルスコアに加算

                scorechange = true;
            }
            else if (Ball.bar_num == 3) //上バーの点数なら
            {
                score3 = score3 + addscore; //上バーのトータルスコアに加算

                scorechange = true;
            }
            else if (Ball.bar_num == 4) //右バーの点数なら
            {
                score4 = score4 + addscore; //右バーのトータルスコアに加算

                scorechange = true;
            }
            addscore = 0;
        }
    }
}
