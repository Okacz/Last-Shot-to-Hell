using UnityEngine;
using System.Collections;

public class firstaidscript : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0.2f, 0);
    }

    void OnTriggerEnter(Collider a)
    {
        if (a.tag == "Player")
        {
            GameObject hero = GameObject.FindGameObjectWithTag("Player");
            ThirdPersonCharacter skrypt = hero.GetComponent<ThirdPersonCharacter>();
            if (skrypt.health < 100)
            {
                if (skrypt.health < 75)
                {
                    skrypt.health += 25;
                    skrypt.healthTxt += 25;
                }
                else
                {
                    skrypt.health = 100;
                    skrypt.healthTxt = 100;
                }
                skrypt.UpdateHealth();
                gameObject.SetActive(false);
            }
        }
    }
}
