using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public float timerInSeconds;
    //[SerializeField]
    public static string timeString;
    void Update()
    {
        Time.timeScale = 1;
        timeString = (Mathf.Floor((timerInSeconds / 60.0f)).ToString()) + ":" + ((Mathf.Floor(timerInSeconds % 60.0f)).ToString("00"));
        timerInSeconds -= Time.deltaTime;
    }
    public string GetTime()
    {
        return timeString;
    }
}
