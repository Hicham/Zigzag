using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float movementSpeed;
    private Vector2 movement;
    private bool angle = true;
    private bool passedstartpoint = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && passedstartpoint == true)
        {
            if (angle == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45f);
                angle = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 315f);
                angle = true;
            }
        }
        if (transform.position.y > -7)
        {
            passedstartpoint = true;
        }
        transform.Translate(Vector2.up * Player.speedUpwards);
    }

    void FixedUpdate () {
        
        
    }
}
