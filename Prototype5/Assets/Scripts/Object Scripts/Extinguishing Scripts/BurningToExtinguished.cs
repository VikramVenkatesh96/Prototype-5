using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningToExtinguished : MonoBehaviour
{
    public static int Score;

    bool isWater = false;
    bool isExtinguished = false;
    private static float countSavedVehicles;
    private const float maxSavesPerLevel = 10;
    private bool switchLevel = false;
    Vehicle vehicleType;


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
            countSavedVehicles++;
            if (countSavedVehicles >= maxSavesPerLevel)
            {
                switchLevel = true;
                Debug.Log("Level change: " + switchLevel);
            }


            // add score here for the corresponding vehicle
            Score = Score + gameObject.GetComponent<Vehicle>().vehicleScore;


            isExtinguished = true;
        }
        else {
            gameObject.GetComponent<Vehicle>().timeToExtinguish -= Time.deltaTime * 2.5f;
        }

    }
}
