using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CollisionExample : MonoBehaviour {

    //Attach this script to the player object

    void OnCollisionEnter2D(Collision2D other)
    {
        // A Check if The object has collided wit something
        Debug.Log("Collided with something");

        // Actions when object collides with another object
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("I have Collided with a Square");
            SceneManager.LoadScene("GameOver");

        }
    }
}
