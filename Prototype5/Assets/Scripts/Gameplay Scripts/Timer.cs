using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public float timerInSeconds;
    private float decrementTimer;
    //[SerializeField]
    private bool isGameOver = false;
    private string timeString;
    //ObjectSpawner vehicleWave;
    void Start()
    {
        decrementTimer = timerInSeconds;
    }
    void Update()
    {
        //Time.timeScale = 1;
        timeString = (Mathf.Floor((decrementTimer / 60.0f)).ToString()) + ":" + ((Mathf.Floor(decrementTimer % 60.0f)).ToString("00"));
        //if (vehicleWave.startWave)
        // {
            decrementTimer -= Time.deltaTime;
        //}
        if (decrementTimer <= 0) {
            timeString = "Finish";
            isGameOver = true;
        }
    }
    public string GetTime()
    {
        return timeString;
    }

    public bool IsGameOver() {
        return isGameOver;
    }
}
