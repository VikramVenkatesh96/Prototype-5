using UnityEngine;
using UnityEngine.UI;

public class Score_manager : MonoBehaviour
{
    // Text objects to show score and high score in UI
    private Text Score;
    private Text Highscore;



    // Int Values to store present score and highscore to show in UI
    public static int Present_score= 0;
    //private int High_score = 0;

    void Start()
    {    
        // Finding text objects to link to variables
        Score = GameObject.Find("Score").GetComponent<Text>();
        Highscore = GameObject.Find("Highscore").GetComponent<Text>();

        // Playerprefs to store/save values
        PlayerPrefs.GetInt("Highscore", 0);

        Score.text = Present_score.ToString();
        Highscore.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    void Update()
    {
        Score_increment_manager();
        Highscore_increment_manager();
        All_debugs();
    }

    //Call function when highscore has to be saved at the end of the level
    void Highscore_increment_manager()
    {
        if(Present_score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Present_score);
            //Highscore.text =
        }
    }

    // call function when score changes only
    void Score_increment_manager()
    {
        Present_score = BurningToExtinguished.Score;
        //if(Input.GetKeyDown(KeyCode.I))
        //{
        //    Present_score++;
        //}
        //else if(Input.GetKeyDown(KeyCode.K))
        //{
        //    Present_score--;
        //}
        Score.text = "Score : " + Present_score.ToString();
    }

    void All_debugs()
    {
        //Debug.Log(Present_score);
        //Debug.Log(PlayerPrefs.GetInt("Highscore"));
    }
}
