using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningToExtinguished : MonoBehaviour
{
    public static int Score;

    bool isWater = false;
    bool isExtinguished = false;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            isWater = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isWater)
        {
            if (!isExtinguished)
            {
                SpawnExtingusihedObject(gameObject);
            }
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            isWater = false;
        }
    }

    private void SpawnExtingusihedObject(GameObject burningObj)
    {
        if (gameObject.GetComponent<Vehicle>().timeToExtinguish <= 0f)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<Vehicle>().extinguishedSprite;
            gameObject.tag = "Extinguished";
            gameObject.transform.parent.gameObject.tag = "Extinguished";
            // add score here
            Score = Score + 10;
            isExtinguished = true;
        }
        else {
            gameObject.GetComponent<Vehicle>().timeToExtinguish -= Time.deltaTime * 2.5f;
        }

    }
}
