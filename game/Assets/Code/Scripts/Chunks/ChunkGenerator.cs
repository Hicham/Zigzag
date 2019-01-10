using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public Transform generationpoint;
    public List<GameObject> ChunkList;

    private List<GameObject> ShuffledList;
    private int rand;
    private float platformHeight;
    private float[] platformHeights;

    void Start()
    {
        ShuffledList = new List<GameObject>();
        //Array voor de juiste afstand voor ieder ingeladen object
        platformHeights = new float[ChunkList.Count];

        //Pakt de Y-as lengte van de boxcollider van het level en zet het level in de array
        for (int i = 0; i < ChunkList.Count; i++)
        {
            platformHeights[i] = ChunkList[i].GetComponent<BoxCollider2D>().size.y;
            GameObject obj = (GameObject)Instantiate(ChunkList[i]);
            obj.SetActive(false);
            ShuffledList.Add(obj);
        }
    }

    void Update()
    {
        if (transform.position.y < generationpoint.position.y)
        {
            GameObject LoadedChunk = PooledChunk();
            platformHeight = LoadedChunk.GetComponent<BoxCollider2D>().size.y;
            transform.position = new Vector2(transform.position.x, transform.position.y + platformHeight);

            LoadedChunk.transform.position = transform.position;
            LoadedChunk.transform.rotation = transform.rotation;
            LoadedChunk.SetActive(true);
        }
    }

    public GameObject PooledChunk()
    {
        if (ShuffledList.Count > 0)
        {
            //Activeren van objecten met rng
            for (int i = 0; i < ShuffledList.Count; i++)
            {
                rand = Random.Range(0, ShuffledList.Count);
                if (!ShuffledList[rand].activeInHierarchy)
                {
                    return ShuffledList[rand];
                }
            }
        }
        return null;
    }

    public void Shuffle()
    {

    }
}