using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningToExtinguished : MonoBehaviour
{
    bool isWater = false;
    public float manExtinguishingTime = 1.0f;
    public float carExtinguishingTime = 3.0f;
    public float truckExtinguishingTime = 5.0f;
    public List<GameObject> extinguishedObjs;
    private List<GameObject> possibleObjsToSpawn;


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
            //find what type the burning object is
            GameObject obj = this.gameObject;
            string objName = obj.name.Split(' ')[1];

            //if burning object is a car
            if (objName == "Car")
            {
                carExtinguishingTime -= Time.deltaTime;
                if (carExtinguishingTime <= 0.0f)
                {
                    spawnExtingusihedObject(obj);
                }
            }
            //if burning object is a truck or a van
            else if (objName == "Truck" || objName == "Van")
            {
                truckExtinguishingTime -= Time.deltaTime;
                if (truckExtinguishingTime <= 0.0f)
                {
                    spawnExtingusihedObject(obj);
                }

            }
            //if burning object is a man
            else if (objName == "Man")
            {
                manExtinguishingTime -= Time.deltaTime;
                if (manExtinguishingTime <= 0.0f)
                {
                    spawnExtingusihedObject(obj);
                }

            }
        }
    }

    private void spawnExtingusihedObject(GameObject burningObj)
    {
        //Add the right type (car/man/truck/van) of object to list of possible extinguished objects to spawn
        foreach(GameObject i in extinguishedObjs)
        {
            if (i.name.Split(' ')[1] == burningObj.name.Split(' ')[1])
            {
                possibleObjsToSpawn.Add(i);
            }
        }
        //At this point we know that the list of possible extinguished objects has the correct type of object that is the type of burningObj
        foreach (GameObject i in possibleObjsToSpawn)
        {
            if (burningObj.name.Split(' ')[2] == i.name.Split(' ')[2])
            {
                GameObject objectToSpawn = i;
                Destroy(this.transform.parent.gameObject);
                objectToSpawn = Instantiate(objectToSpawn) as GameObject;
                break;
            }
        }
    }
}
