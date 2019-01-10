using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDestroyer : MonoBehaviour {
    public GameObject ChunkDestructionPoint;

	void Start () {
        //Checkt voor destruction point
        ChunkDestructionPoint = GameObject.Find("ChunkDestructionPoint");
	}
	
	void Update () {
        //Checkt als destruction point voorbij het object is
		if (transform.position.y < ChunkDestructionPoint.transform.position.y)
        {
            gameObject.SetActive(false); 
        }
	}
}
