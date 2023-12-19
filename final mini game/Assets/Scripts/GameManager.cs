using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;

    public Button replayButton;
    public Button startButton;
    public GameObject coinText;

    // Start is called before the first frame update
    void Start()
    {
        replayButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        coinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameActive = false;
        replayButton.gameObject.SetActive(true);
        
    }

    public void PressReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PressStartButton()
    {
        isGameActive = true;
        coinText.SetActive(true);
        startButton.gameObject.SetActive(false);
        GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().SpawnCollectibleObject();
        GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().StartCreatingZombies();
    }
}
