using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    //private GameObject water;
    private Animator waterAnimator;
    void Start()
    {
        /*water = gameObject.transform.GetChild(0).gameObject;
        water.SetActive(false);*/
        waterAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(waterAnimator.GetBool("waterActive"));
    }

    void OnMouseDown()
    {
        //water.SetActive(true);
        waterAnimator.SetBool("waterActive", true);
    }
    void OnMouseUp()
    {
        //water.SetActive(false);
        waterAnimator.SetBool("waterActive", false);
    }
}
