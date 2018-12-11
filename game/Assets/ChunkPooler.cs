using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPooler : MonoBehaviour {

    public GameObject PooledChunk;
    public int PooledAmount;
    List<GameObject> Chunks;

    void Start () {
        //Maakt nieuwe lijst aan van gameobjects
        Chunks = new List<GameObject>();

        //Loop om objecten inactief te instantiaten en ze aan de lijst toevoegen
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(PooledChunk);
            obj.SetActive(false);
            Chunks.Add(obj);
        }
	}

    public GameObject GetPooledChunk()
    {
        //Activeren van objecten
        for (int i = 0; i < Chunks.Count; i++)
        {
            if (!Chunks[i].activeInHierarchy)
            {
                return Chunks[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(PooledChunk);
        obj.SetActive(false);
        Chunks.Add(obj);
        return obj;

    }
}
