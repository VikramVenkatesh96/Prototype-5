using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    private BoxCollider2D water;
    private Animator waterAnimator;
    private AudioSource audioSource;
    void Start()
    {
        water = gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        water.enabled = false;
        waterAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Debug.Log(waterAnimator.GetBool("waterActive"));
    }

    void OnMouseDown()
    {
        water.enabled = true;
        waterAnimator.SetBool("waterActive", true);
        audioSource.Play();
    }
    void OnMouseUp()
    {
        water.enabled = false;
        waterAnimator.SetBool("waterActive", false);
        audioSource.Stop();
    }
}
