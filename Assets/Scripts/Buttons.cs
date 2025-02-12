using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
     public void ResetGame()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

     }
    public void Quit()
    {
         SceneManager.LoadScene("Menu");
 
    }
}
