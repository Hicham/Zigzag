using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public Transform generationpoint;
    public List<GameObject> ChunkList;
    public GameObject[] ChunkArray;

    private int rand;
    private float platformHeight;
    private float[] platformHeights;

    void Start()
    {
        //Array voor de juiste afstand voor ieder ingeladen object
        platformHeights = new float[ChunkList.Count];

        //Pakt de Y-as lengte van de boxcollider van het level en zet het level in de array
        for (int i = 0; i < ChunkList.Count; i++)
        {
            platformHeights[i] = ChunkList[i].GetComponent<BoxCollider2D>().size.y;
            Debug.Log(platformHeights[i]);
        }
    }

    void Update()
    {
        if (transform.position.y < generationpoint.position.y)
        {
            //Met random nummer een chunkpool selecteren om in te laden
            rand = Random.Range(0, ChunkList.Count);
            transform.position = new Vector2(transform.position.x, transform.position.y + platformHeights[rand]);

            GameObject LoadedChunk = PooledChunk();
            LoadedChunk.transform.position = transform.position;
            LoadedChunk.transform.rotation = transform.rotation;
            LoadedChunk.SetActive(true);
        }
    }

    public GameObject PooledChunk()
    {
                    //Activeren van objecten
            for (int i = 0; i<ChunkList.Count; i++)
            {
                if (!ChunkList[i].activeInHierarchy)
                {
                    return ChunkList[i];
                }
            }

            GameObject BufferedChunk = (GameObject)Instantiate(ChunkList[rand]);
            BufferedChunk.SetActive(false);
            return BufferedChunk;

    }
}
