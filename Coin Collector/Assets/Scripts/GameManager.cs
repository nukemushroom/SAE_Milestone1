using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused;

    public int numberToSpawn = 10;
    private int coins;

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        for(var i = 0; i < numberToSpawn; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-50, 50), 1, (Random.Range(-50, 50))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    
    public void AddCollectedCoin(int score)
    {
        coins += score;
        if(coins >= numberToSpawn)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("WinScreen");
        }
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            isPaused = !isPaused;
        }
    }
}
