using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PlayerCollisions : MonoBehaviour {
  
    void OnCollisionEnter2D(Collision2D other)
    {
 
        if (other.gameObject.CompareTag("Object"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
