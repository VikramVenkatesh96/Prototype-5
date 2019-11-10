using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour

{

    public List<GameObject> objects;
    public List<GameObject> spawnPos;
    public float respawnTime;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(objectsWave());
    }

    private void spawnObjects()
    {
        //select a random gameobject to spawn
        GameObject objectToSpawn = objects[Random.Range(0, objects.Count)];
        objectToSpawn = Instantiate(objectToSpawn) as GameObject;

        //spawn the object on the right side 
        //objectToSpawn.transform.position = new Vector2(screenBounds.x * -2, spawnPos[Random.Range(0, spawnPos.Count - 1)].transform.position.y);
        objectToSpawn.transform.position = new Vector2(spawnPos[0].transform.position.x, spawnPos[Random.Range(0, spawnPos.Count)].transform.position.y);
    }

    IEnumerator objectsWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObjects();
        }
        
    }

}
