using UnityEngine;
using System.Collections;

public class placeammo : MonoBehaviour
{

    public int revAmmo;
    public int shotAmmo;
    public int dynAmmo;

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
            skrypt.revolverAmmo += revAmmo;
            skrypt.shotgunAmmo += shotAmmo;
            skrypt.dynamiteAmmo += dynAmmo;
            skrypt.UpdateAmmo();
            gameObject.SetActive(false);
        }
    }
}
