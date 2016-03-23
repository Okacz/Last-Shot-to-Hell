using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public void StartTheGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("scena1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
