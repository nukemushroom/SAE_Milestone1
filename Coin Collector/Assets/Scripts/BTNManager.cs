using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour
{
    //Method that sends you to the new scene(the argument is the scene's name)
    public void NewLevelBtn(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }

    //Method that exits the game
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
