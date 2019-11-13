using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public Text Time;

    void Update()
    {
        Time.text = "Time : " + Timer.timeString;
    }
}
