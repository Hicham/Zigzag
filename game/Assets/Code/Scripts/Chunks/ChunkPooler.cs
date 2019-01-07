using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPooler : MonoBehaviour {

    public GameObject DummyChunk;
    public int PooledAmount;
    public List<GameObject> Chunks;

    void Start() {
        
        //for-Loop om objecten inactief te instantiaten
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Chunks[i]);
            obj.SetActive(false);
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

        GameObject obj = (GameObject)Instantiate(DummyChunk);
        obj.SetActive(false);
        return obj;

    }
}
