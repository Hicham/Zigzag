using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public Transform generationpoint;
    public ChunkPooler[] ChunkPools;

    private int rand;
    private float platformHeight;
    private float[] platformHeights;

    void Start()
    {
        //Zorgt voor de juiste afstand voor ieder ingeladen object
        platformHeights = new float[ChunkPools.Length];

        for (int i = 0; i < ChunkPools.Length; i++)
        {
            platformHeights[i] = ChunkPools[i].PooledChunk.GetComponent<BoxCollider>().size.y;
        }
    }

    void Update()
    {
        if (transform.position.y < generationpoint.position.y)
        {
            //Met random nummer een chunkpool selecteren om in te laden
            int rand = Random.Range(0, ChunkPools.Length);
            transform.position = new Vector2(transform.position.x, transform.position.y + platformHeights[rand]);

            GameObject NewChunk = ChunkPools[rand].GetPooledChunk();
            NewChunk.transform.position = transform.position;
            NewChunk.transform.rotation = transform.rotation;
            NewChunk.SetActive(true);
            Debug.Log(rand);
        }
    }
}
