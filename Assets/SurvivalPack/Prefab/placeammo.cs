using UnityEngine;
using System.Collections;

public class placeammo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.2f, 0);
    }

    void OnTriggerEnter(Collider a)
    {
        if (a.tag == "Player")
        {
            GameObject hero = GameObject.FindGameObjectWithTag("Player");
            ThirdPersonCharacter skrypt = hero.GetComponent<ThirdPersonCharacter>();
            skrypt.revolverAmmo += 18;
            skrypt.shotgunAmmo += 2;
            skrypt.dynamiteAmmo += 1;
            skrypt.UpdateAmmo();
            gameObject.SetActive(false);
        }
    }
}
