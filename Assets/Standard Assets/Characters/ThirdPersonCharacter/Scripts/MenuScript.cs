using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    bool isMenuUp;
    public Transform Menu;
    public Transform DeadText;
    Transform Camera;
    
    float HP = 100;

    // Use this for initialization
    void Start () {
        isMenuUp = false;
        Menu.gameObject.SetActive(false);
        DeadText.gameObject.SetActive(false);
        Camera = GameObject.Find("Main Camera").transform;
        GameObject playa = GameObject.Find("PlayerCharacter");
        ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
        HP = skrypt.health;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject playa = GameObject.Find("PlayerCharacter");
            ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
            HP = skrypt.health;
            //print(HP);
            if (HP > 0)
            {
                if (isMenuUp == true)
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
	}
    public void GetMenuUp()
    {
        GameObject playa = GameObject.Find("PlayerCharacter");
        ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
        HP = skrypt.health;
        if (HP <= 0)
        {
            DeadText.gameObject.SetActive(true);
        }
            Menu.gameObject.SetActive(true);
            Time.timeScale = 0;
            isMenuUp = true;
            Camera.GetComponent<AudioSource>().Pause();
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        DeadText.gameObject.SetActive(false);
        skrypt.respawn();
        /*Menu.gameObject.SetActive(false);
        isMenuUp = false;
        Camera.GetComponent<AudioSource>().Stop();
        Camera.GetComponent<AudioSource>().Play();*/
        
    }
}
