using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public KeyCode Movekey = KeyCode.LeftControl;
    public float movementSpeed;
    private Vector2 movement;
    private bool angle = true;
    private bool passedstartpoint = false;

    private void Update()
    {
        KeyPhase();
        //check if key or touch and beyond the starting point
        if (Input.GetKeyDown(Movekey) && passedstartpoint == true)
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
        transform.Translate(Vector2.up);
    }

    public void KeyPhase()
    {
        if (Input.GetKeyDown(Movekey))
        {
            Debug.Log("Down");
        }
        if (Input.GetKeyUp(Movekey))
        {
            Debug.Log("Up");
        }
    }
}
