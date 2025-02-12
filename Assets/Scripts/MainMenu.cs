using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class MainMenu : MonoBehaviour
{
 
     public Moveleft[ ] Moveleft; 
    public GameObject mainMenu;
    public PlayerController playerController;  
    public SpawnManager spawnManager; 
 
    public void PlayGame()
    {
    SceneManager.LoadScene("Game");
     }
}
