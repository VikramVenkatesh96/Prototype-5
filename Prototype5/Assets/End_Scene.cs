using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Scene : MonoBehaviour
{
    public GameObject UI;

    void Start()
    {
        UI.SetActive(false);
    }

    void Update()
    {
        if(Death_counter_manager.Game_ended == true)
        {
            UI.SetActive(true);
            Death_counter_manager.Game_ended = false;
        }
        else
        {
            UI.SetActive(false);
        }
    }


}
