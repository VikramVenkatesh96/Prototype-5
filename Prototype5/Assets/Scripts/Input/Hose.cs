using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    private BoxCollider2D water;
    private Animator waterAnimator;
    void Start()
    {
        water = gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        water.enabled = false;
        waterAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(waterAnimator.GetBool("waterActive"));
    }

    void OnMouseDown()
    {
        water.enabled = true;
        waterAnimator.SetBool("waterActive", true);
    }
    void OnMouseUp()
    {
        water.enabled = false;
        waterAnimator.SetBool("waterActive", false);
    }
}
