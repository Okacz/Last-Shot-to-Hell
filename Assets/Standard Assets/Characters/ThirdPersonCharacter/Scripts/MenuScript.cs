using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    bool isMenuUp;
    public Transform Menu;
    Transform Camera;
	// Use this for initialization
	void Start () {
        isMenuUp = false;
        Menu.gameObject.SetActive(false);
        Camera = GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuUp==true)
            {
                Menu.gameObject.SetActive(false);
                Time.timeScale = 1;
                isMenuUp = false;
                Camera.GetComponent<AudioSource>().UnPause();
            }
            else
            if (isMenuUp == false)
            {
                Menu.gameObject.SetActive(true);
                Time.timeScale = 0;
                isMenuUp = true;
                Camera.GetComponent<AudioSource>().Pause();
            }
        }
	}
    public void GetMenuUp()
    {
        Menu.gameObject.SetActive(true);
        Time.timeScale = 0;
        isMenuUp = true;
        Camera.GetComponent<AudioSource>().Pause();
    }
    public void ToMainMenu()
    {
        Application.LoadLevel("main_menu");
    }
    public void Exit()
    {
        print("dedededed");
        Application.Quit();
    }
    public void Continue()
    {
        GameObject playa = GameObject.Find("PlayerCharacter");
        ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
        skrypt.respawn();
        Menu.gameObject.SetActive(false);
        Time.timeScale = 1;
        isMenuUp = false;
        Camera.GetComponent<AudioSource>().Stop();
        Camera.GetComponent<AudioSource>().Play();
        
    }
}
