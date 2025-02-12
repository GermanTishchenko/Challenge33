using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
 
     private Vector3 initialPosition;
    private Vector3 offScreenPosition;
private PlayerController playerControllerScript;
    public float slideSpeed = 5f; 
     public GameObject player;
    private bool isSliding = false;

    void Start()
    {
 
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
     // Remembers the starting position
          initialPosition = transform.position;
 // Moves it far below the camera view
        offScreenPosition = initialPosition + new Vector3(0, -1000, 0);
    // Moves it away
        transform.position = offScreenPosition;
    }

    void Update()
    {

  // When player dies menu slides and stops when it reaches the initial position 
         if ( playerControllerScript.gameOver == true)
        {
            isSliding = true;
        }
 
         if (isSliding)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, slideSpeed * Time.deltaTime);

             if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
            {
                transform.position = initialPosition;
                isSliding = false;
            }
        }

    }
}
