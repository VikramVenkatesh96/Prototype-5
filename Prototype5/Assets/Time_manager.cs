using UnityEngine;
using UnityEngine.UI;

public class Time_manager : MonoBehaviour
{
    public Text Time;

    public Timer String;

    void Update()
    {
        Time.text = String.GetTime();
    }
}
