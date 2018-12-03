using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform player;
    public Vector3 offset;


    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        
        transform.position = new Vector3 (offset.x,  player.position.y + offset.y, offset.z);
    }
}
