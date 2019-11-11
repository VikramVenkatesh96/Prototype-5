using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGen : MonoBehaviour
{
    public bool autoUpdate;
    [SerializeField]
    private int numberOfRows;
    public int minNumberPerRow;
    public int maxNumberPerRow;
    public Sprite[] blockTypes;
    public GameObject blockPrefab;

    [Header("Noise Settings")]
    public int octaves;
    public float persistance;
    public float lacunarity;


    public void GenerateBlocks() {
        //First child of the current GameObject
        Transform parent = gameObject.transform.GetChild(0);

        for (int i = 0; i < numberOfRows; ++i) {
            int numOfBlocks = Random.Range(minNumberPerRow,maxNumberPerRow);
            for (int j = 0; j < numOfBlocks; ++j) {
                Vector3 blockPos = new Vector3(j * 0.5f, i * 0.3f, 0.0f);
                float amplitude = 1;
                float frequency = 1;
                float noiseValue = 0;
                for (int k = 0; k < octaves; ++k)
                {
                    noiseValue = Mathf.PerlinNoise((j + 0.1f) / numOfBlocks * numberOfRows * frequency, (i + 0.1f) / numOfBlocks * numberOfRows * frequency);
                    noiseValue += noiseValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
               
                GameObject block = Instantiate(blockPrefab, blockPos, Quaternion.Euler(0,0,0), parent);
                if (noiseValue > 0.6f)
                {
                    block.GetComponent<SpriteRenderer>().sprite = blockTypes[0];
                }
                else if (noiseValue < 0.4f)
                {
                    block.GetComponent<SpriteRenderer>().sprite = blockTypes[2];
                }
                else {
                    block.GetComponent<SpriteRenderer>().sprite = blockTypes[1];
                }
               
            }
        }
    }

    public void DestroyBlocks() {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            DestroyImmediate(block);
        }
    }
}
