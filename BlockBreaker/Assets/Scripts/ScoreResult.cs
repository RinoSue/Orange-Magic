using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreResult : MonoBehaviour
{
    private int[] totalscore = new int[4]; //4人のトータルスコアを格納する配列
    private string[] namescore; //4人の名前とトータルスコアを格納する配列
    private int[] nametest = new int [4];
    private GameObject you; 
    private GameObject ponta; 
    private GameObject gonta; 
    private GameObject zonta; 

    [SerializeField]
    private TextMeshProUGUI totalScoreText1; //トータルスコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI totalScoreText2; //トータルスコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI totalScoreText3; //トータルスコアを記すテキスト
    [SerializeField]
    private TextMeshProUGUI totalScoreText4; //トータルスコアを記すテキスト

    // Start is called before the first frame update
    void Start()
    {
        //string[] namescore = { "Ponta", "Zonta", "Gonta", "You" };

        you = GameObject.FindGameObjectWithTag("PlayerBar");
        you.SetActive(false);
        ponta = GameObject.FindGameObjectWithTag("LeftBar");
        ponta.SetActive(false);
        gonta = GameObject.FindGameObjectWithTag("UpBar");
        gonta.SetActive(false);
        zonta = GameObject.FindGameObjectWithTag("RightBar");
        zonta.SetActive(false);

        totalscore = DisplayScore.getScore();

        //Array.Sort(totalscore);
        //Array.Reverse(totalscore);

        //nametest = DisplayScore.getScore();

        /*
        for (int i = 0; i < 4; i++)
        {
            if (totalscore[i] == nametest[0])
            {
                namescore[i] = "You(" + totalscore[i] + ")";

                if (i == 0)
                {
                    you.SetActive(true);
                }

            }
            else if (totalscore[i] == nametest[1])
            {
                namescore[i] = "Ponta(" + totalscore[i] + ")";

                if (i == 0)
                {
                    ponta.SetActive(true);
                }
            }
            else if (totalscore[i] == nametest[2])
            {
                namescore[i] = "Gonta(" + totalscore[i] + ")";

                if (i == 0)
                {
                    gonta.SetActive(true);

                }

            }
            else if (totalscore[i] == nametest[3])
            {
                namescore[i] = "Zonta(" + totalscore[i] + ")";

                if (i == 0)
                {
                    zonta.SetActive(true);
                }

            }
        }
        */

        /*
        string[] namescore = { "You", "Ponta", "Gonta", "Zonta" };

        string[] namescore1 = { "First", "Second", "Third", "Fourth" };

        string[] namescore2 = { "First", "Second", "Third", "Fourth" };


        //並び替える前のやつ
        for (int i = 0; i < nametest.Length; i++)
        {
           //並び替えた後のやつ
            for(int j = 0; j < totalscore.Length; j++)
            {
                //namescore[i]さんはnametest[i]点でj位
                if (nametest[i] == totalscore[j])
                {
                    namescore2[i] = namescore[i] + "(" + nametest[i] + ")"; 
                }
            }
        }
        */

        
        //スコア表示の初期設定
        totalScoreText1.text = $"You : {totalscore[0]}";
        //スコア表示の初期設定
        totalScoreText2.text = $"Ponta : {totalscore[1]}";
        //スコア表示の初期設定
        totalScoreText3.text = $"Gonta : {totalscore[2]}";
        //スコア表示の初期設定
        totalScoreText4.text = $"Zonta : {totalscore[3]}";
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
