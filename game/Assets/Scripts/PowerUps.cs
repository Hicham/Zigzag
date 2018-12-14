using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public bool doublePoints;

    public float powerupLength;

    private Powerupmanager thepowerupmanager;

	// Use this for initialization
	void Start () {
        thepowerupmanager = FindObjectOfType<Powerupmanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thepowerupmanager.ActivatePowerup(doublePoints, powerupLength); 
        }
        gameObject.SetActive(false);
    }
}
