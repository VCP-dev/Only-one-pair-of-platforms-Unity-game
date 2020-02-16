using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public GameObject playa;
    public Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore.text = "High Score : " + PlayerPrefs.GetInt("Highscore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
              if(ScoreScript.scorevalue > PlayerPrefs.GetInt("Highscore",0))
                {
                    PlayerPrefs.SetInt("Highscore",ScoreScript.scorevalue);
                }
          
    }
}
