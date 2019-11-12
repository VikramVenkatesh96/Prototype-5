using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public float timerInSeconds;
    [SerializeField]
    private string timeString;
    void Update()
    {
        timeString = (Mathf.Floor((timerInSeconds / 60.0f)).ToString()) + ":" + ((Mathf.Floor(timerInSeconds % 60.0f)).ToString("00"));
        timerInSeconds -= Time.deltaTime;
    }
    public string GetTime()
    {
        return timeString;
    }
}
