using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Moveleft : MonoBehaviour
{
public SpawnManager spawnManager; 
public float speed = 30;
public float maxspeed = 65;

private PlayerController playerControllerScript;

  void Start() {
  playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
 }
 // Resets speed when player dies
  public void Resetspeed() {
  speed = 30;
}
private float leftBound = -15;
public float counter = 0f;
void Update() {
  if (playerControllerScript.gameOver == false) {
    transform.Translate(Vector3.left * Time.deltaTime * speed);
  }
  if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
    Destroy(gameObject);
    }
}
// Increases speed of background and obstacles
   public void morespeed() {
        speed += 1;   
         if (speed > maxspeed) {
            speed = maxspeed; 
        }
    transform.Translate(Vector3.left * Time.deltaTime * speed);
     }
 
}
