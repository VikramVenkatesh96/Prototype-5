using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour

{

    public List<GameObject> objectsLeftToRight;
    public List<GameObject> objectsRightToLeft;
    public List<GameObject> spawnPos;
    public float respawnTime;
    public float delayBetweenLevels;
    public bool startWave = true;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(objectsRToLWave());

        StartCoroutine(delayBetweenLAndRWaves());

        StartCoroutine(objectsLToRWave());
    }

    private void spawnObjectsRightToLeft()
    {
        //select a random gameobject to spawn
        GameObject objectToSpawn = objectsRightToLeft[Random.Range(0, objectsRightToLeft.Count)];
        objectToSpawn = Instantiate(objectToSpawn) as GameObject;

        //spawn the object on the right side 
        //int chosenSpawnPoint = Random.Range(0, spawnPos.Count);
        objectToSpawn.transform.position = new Vector2(spawnPos[0].transform.position.x, spawnPos[0].transform.position.y);
    }

    private void spawnObjectsLeftToRight()
    {
        //select a random gameobject to spawn
        GameObject objectToSpawn = objectsLeftToRight[Random.Range(0, objectsLeftToRight.Count)];
        objectToSpawn = Instantiate(objectToSpawn) as GameObject;

        //spawn the object on the left side 
        objectToSpawn.transform.position = new Vector2(spawnPos[1].transform.position.x, spawnPos[1].transform.position.y);
    }

    IEnumerator objectsRToLWave()
    {
        while(true)
        {
            if(startWave)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnObjectsRightToLeft();
            }
            else
            {
                yield return new WaitForSeconds(delayBetweenLevels);
                startWave = true;
            }
            
        }
        
    }

    IEnumerator delayBetweenLAndRWaves()
    {
        yield return new WaitForSeconds(2f);

    }



    IEnumerator objectsLToRWave()
    {
        while (true)
        {
            if (startWave)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnObjectsLeftToRight();
            }
            else
            {
                yield return new WaitForSeconds(delayBetweenLevels);
                startWave = true;
            }
        }

    }

}
