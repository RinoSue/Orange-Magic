using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGuideButton : MonoBehaviour
{
    [SerializeField]
    private GameObject playguide1;
    [SerializeField]
    private GameObject playguide2;
    [SerializeField]
    private GameObject playguide3;

    // Start is called before the first frame update
    void Start()
    {
        //playguide1 = GameObject.Find("PlayGuide1");
        playguide1.SetActive(true);
        //playguide2 = GameObject.Find("PlayGuide2");
        playguide2.SetActive(false);
        //playguide3 = GameObject.Find("PlayGuide3");
        playguide3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToPlayGuide2()
    {
        playguide1.SetActive(false);
        playguide2.SetActive(true);
    }

    public void ToPlayGuide3()
    {
        playguide2.SetActive(false);
        playguide3.SetActive(true);
    }

    public void ClosePlayGuide()
    {
        //ゲーム画面へ遷移
        SceneManager.LoadScene("GameTitle");
    }
}
