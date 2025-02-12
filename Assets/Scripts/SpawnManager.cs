using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 1;
    private float repeatRate = 3.0f;
    private float minRepeatRate = 1.5f;
    public float counter = 0f;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public TextMeshProUGUI counterText;
    public Moveleft[] Moveleft;

    private PlayerController playerControllerScript;
    void Start()
    {
        repeatRate = 4.0f;
        counter = 0f;
        startDelay = 2;

        CancelInvoke("SpawnObstacle");
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        counterText.text = "Counter: " + counter.ToString();
    }
// Repeadetly spawns obstacles if player is not dead
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            IncrementCounter();
        }
    }
// Increases speed of background and obstacles
    void IncrementCounter()
    {
        foreach (Moveleft moveLeftInstance in Moveleft)
        {
            moveLeftInstance.morespeed();
        }
        counter += 1;
        counterText.text = "Counter: " + counter.ToString();
// Every 5 scores jumpheight and spawnrate increase
        if (counter % 5 == 0)
        {
            DecreaseRepeatRate();
            playerControllerScript.HigherJump();
        }
    }
 // Decreases repeat rate if it's higher than minimum 
    private void DecreaseRepeatRate()
    {
        repeatRate -= 0.5f;
        if (repeatRate < minRepeatRate)
        {
            repeatRate = minRepeatRate;
        }
        CancelInvoke("SpawnObstacle");
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
}
