using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public Text Time;
    public Timer timer;
    void Update()
    {
        Time.text = "Time : " + timer.GetTime();
    }
}
