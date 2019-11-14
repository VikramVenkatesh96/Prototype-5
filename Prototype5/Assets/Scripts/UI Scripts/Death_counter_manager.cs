﻿using UnityEngine;
using UnityEngine.UI;

public class Death_counter_manager : MonoBehaviour
{
    public float Fill_amount;
    public float Fill_decreamentor;
    public float Fill_incrementor;

    public Image Death_bar_outline_image;
    public Image Death_bar_filler_image;
    public Text Death_counter_filled_text;

    private float Bar_controler;

    public static bool Game_ended;

    public Timer timer_string;

    void Start()
    {
        Death_bar_filler_image.fillAmount = 0;

        Time.timeScale = 1;

        Game_ended = false;

        Bar_controler = 1 / BurningToExtinguished.maxSavesPerLevel;

        Fill_amount = 0.1f;
        Fill_incrementor = 0.1f;
        Fill_decreamentor = -0.1f;

        Death_counter_filled_text.gameObject.SetActive(false);
    }

    void Update()
    {
        //Death_count_manager_script();

        saved_vehicles_count_for_bar();

        Show_menu_if_bar_filled();

        //Pause_game();

        All_degug_here();
    }


    void saved_vehicles_count_for_bar()
    {
        //Debug.Log("saved vehicles: " + BurningToExtinguished.countSavedVehicles);
        if (Death_bar_filler_image.fillAmount == 1)
        {
            Death_bar_filler_image.fillAmount = 0;
        }
        Death_bar_filler_image.fillAmount = (BurningToExtinguished.countSavedVehicles % BurningToExtinguished.maxSavesPerLevel) * Bar_controler;
        
    }

    void Show_menu_if_bar_filled()
    {
        if(Death_bar_filler_image.fillAmount >= 1)
        {
            End_screen_manager.show_menu = true;
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
        }
    }

    void Pause_game()
    {
        if(timer_string.GetTime() == "0:00")
        {
            End_screen_manager.show_menu = true;
            Time.timeScale = 0;
        }
    }

    //inputs for temporary usage
    void Death_count_manager_script()
    {

        //Debug.Log(Death_bar_filler_image.fillAmount);

        if (Death_bar_filler_image.fillAmount == 1)
        {
            Death_counter_filled_text.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Game_ended = true;
        }

        Death_bar_filler_image.fillAmount = BurningObjectCounter.objMissedCount * Bar_controler * 5;

        /*if (Input.GetKeyDown(KeyCode.U))
        {
            Death_bar_filler_image.fillAmount = Fill_amount + Fill_incrementor;
            Fill_amount = Death_bar_filler_image.fillAmount;
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            Death_bar_filler_image.fillAmount = Fill_amount + Fill_decreamentor;
            Fill_amount = Death_bar_filler_image.fillAmount;
        }*/
    }

    void All_degug_here()
    {
        //Debug.Log(Death_bar_filler_image.fillAmount);
    }
}
