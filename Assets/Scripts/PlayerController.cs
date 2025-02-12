using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
public GameObject Over;
public SpawnManager spawnManager; 

private Rigidbody playerRb;
public float jumpForce = 1100f;
public float gravityModifier = 4f;
private readonly Vector3 defaultGravity = new Vector3(0, -9.81f, 0);  
public bool gameOver = false;
public bool gameStarted = false; 
private Animator playerAnim;
public ParticleSystem explosionParticle;
public ParticleSystem dirtParticle;
public AudioClip jumpSound;
public int life = 3;
public TextMeshProUGUI lifeCounter;
 public GameObject mainMenu;
    public Moveleft[ ] Moveleft; 

public AudioClip crashSound;
private AudioSource playerAudio;
   public void HigherJump() {
   if (jumpForce < 1750f)
  {   jumpForce += 140; }
}

  void Start() {
   Physics.gravity = defaultGravity * gravityModifier;

  playerRb = GetComponent<Rigidbody>();
  playerAnim = GetComponent<Animator>();
 playerAudio = GetComponent<AudioSource>(); 
 gameStarted = true;
  Debug.Log("Game Started!");
life = 3;
lifeCounter.text = "Lives: " + life.ToString();   
    gameOver = false; 
}
public bool isOnGround = true;

void Update() {
 
  if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    isOnGround = false;
    playerAnim.SetTrigger("Jump_trig");
 dirtParticle.Stop(); 
playerAudio.PlayOneShot(jumpSound, 1.0f);
  }

}
 
private void OnCollisionEnter(Collision collision) {
  if (collision.gameObject.CompareTag("Ground")) {
    isOnGround = true;
 dirtParticle.Play(); 
  } 
      // If player has lives he destroys object 
  else if (collision.gameObject.CompareTag("Obstacle") && life > 1) {
 explosionParticle.Play(); 
 playerAudio.PlayOneShot(crashSound, 1.0f);
Destroy(collision.gameObject);
        life -= 1;  
        lifeCounter.text = "Lives: " + life.ToString();   

  }

    // if he doesn't he dies
  else if (collision.gameObject.CompareTag("Obstacle")) {
    Debug.Log("Game Over");
    gameOver = true;
    playerAnim.SetBool("Death_b", true);
    playerAnim.SetInteger("DeathType_int", 1);
explosionParticle.Play(); 
 dirtParticle.Stop(); 
playerAudio.PlayOneShot(crashSound, 1.0f);
        life -= 1;  
        lifeCounter.text = "Lives: " + life.ToString();   
      foreach (Moveleft moveLeftInstance in Moveleft)
    {
        moveLeftInstance.Resetspeed();
    }
 
  }
}
}
