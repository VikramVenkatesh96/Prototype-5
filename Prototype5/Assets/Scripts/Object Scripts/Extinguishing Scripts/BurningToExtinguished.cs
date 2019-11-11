using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningToExtinguished : MonoBehaviour
{
    bool isWater = false;
    bool isExtinguished = false;
    //public float manExtinguishingTime = 1.0f;
    //public float carExtinguishingTime = 0.5f;
    //public float truckExtinguishingTime = 0.5f;
    //public List<GameObject> extinguishedObjs;
    //private List<GameObject> possibleObjsToSpawn;


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
            //find what type the burning object is
            //    GameObject obj = this.gameObject.transform.parent.gameObject;
            //    string objName = obj.name.Split(' ')[1];

            //    //if burning object is a car
            //    if (objName == "Car")
            //    {
            //        carExtinguishingTime -= Time.deltaTime * 50;
            //        if (carExtinguishingTime <= 0.0f)
            //        {
            //            SpawnExtingusihedObject(gameObject);
            //        }
            //    }
            //    //if burning object is a truck or a van
            //    else if (objName == "Truck" || objName == "Van")
            //    {

            //        truckExtinguishingTime -= Time.deltaTime;
            //        if (truckExtinguishingTime <= 0.0f)
            //        {
            //            SpawnExtingusihedObject(gameObject);
            //        }

            //    }
            //    //if burning object is a man
            //    else if (objName == "Man")
            //    {
            //        manExtinguishingTime -= Time.deltaTime;
            //        if (manExtinguishingTime <= 0.0f)
            //        {
            //            SpawnExtingusihedObject(gameObject);
            //        }

            //    }
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
            isExtinguished = true;
        }
        else {
            gameObject.GetComponent<Vehicle>().timeToExtinguish -= Time.deltaTime * 2.5f;
        }
            
       //possibleObjsToSpawn = new List<GameObject>();

        ////Add the right type (car/man/truck/van) of object to list of possible extinguished objects to spawn
        //foreach (GameObject i in extinguishedObjs)
        //{
        //    if (i.name.Split(' ')[1] == burningObj.name.Split(' ')[1])
        //    {
        //        possibleObjsToSpawn.Add(i);
        //    }
        //}
        ////At this point we know that the list of possible extinguished objects has the correct type of object that is the type of burningObj
        //foreach (GameObject i in possibleObjsToSpawn)
        //{
        //    if (burningObj.name.Split(' ')[2] == i.name.Split(' ')[2])
        //    {
        //        GameObject objectToSpawn = i;
        //        Destroy(this.transform.parent.gameObject);
        //        objectToSpawn = Instantiate(objectToSpawn) as GameObject;
        //        break;
        //    }
        //}
    }
}
