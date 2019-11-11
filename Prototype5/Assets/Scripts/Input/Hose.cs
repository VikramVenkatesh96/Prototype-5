using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    private GameObject water;
    void Start()
    {
        water = gameObject.transform.GetChild(0).gameObject;
        water.SetActive(false);
    }

    void OnMouseDown()
    {
        water.SetActive(true);
    }
    void OnMouseUp()
    {
        water.SetActive(false);
    }
}
