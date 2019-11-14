using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_screen_manager : MonoBehaviour
{
    public Text Score;
    public Text Highscore;
    public Text No_saved;
    public Image Background;
    public Button Store;
    public Button Retry;

    public Timer Timer_obj;

    public static bool show_menu;

    void Start()
    {
        show_menu = false;
        Score.gameObject.SetActive(false);
        Highscore.gameObject.SetActive(false);
        No_saved.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        Retry.gameObject.SetActive(false);
        Store.gameObject.SetActive(false);
        //Debug.Log("START");
    }

    void Update()
    {
        if(Timer_obj.IsGameOver() == true)
        {
            show_menu = true;
            Time.timeScale = 0;
        }
        Show_menu();
        Score.text = "Score :       " + Score_manager.Present_score.ToString();
        Highscore.text = "Highscore :   " + PlayerPrefs.GetInt("Highscore").ToString();
        No_saved.text = "Saved Cars :   " + BurningToExtinguished.countSavedVehicles.ToString(); 
    }

    public void Store_button()
    {

    }

    public void first_set_ui_false()
    {
        Time.timeScale = 1;
        show_menu = false;
        Score.gameObject.SetActive(false);
        Highscore.gameObject.SetActive(false);
        No_saved.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        //Retry.gameObject.SetActive(false);
        Store.gameObject.SetActive(false);
    }

    public void Retry_button()
    {

        show_menu = false;
        SceneManager.LoadScene("Startpage");
        Debug.Log("Scene reloaded");
    }

    void Show_menu()
    {
        if(show_menu == false)
        {
            Score.gameObject.SetActive(false);
            Highscore.gameObject.SetActive(false);
            No_saved.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            Retry.gameObject.SetActive(false);
            Store.gameObject.SetActive(false);
            //Debug.Log("SET TO FALSE");
        }
        else if (show_menu == true)
        {
            Time.timeScale = 0;
            Score.gameObject.SetActive(true);
            Highscore.gameObject.SetActive(true);
            No_saved.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            Retry.gameObject.SetActive(true);
            Store.gameObject.SetActive(true);
        }

    }
}
