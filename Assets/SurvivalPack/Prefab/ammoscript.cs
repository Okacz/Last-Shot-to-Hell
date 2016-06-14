using UnityEngine;
using System.Collections;

public class ammoscript : MonoBehaviour {

    public int revAmmo;
    public int shotAmmo;
    public int dynAmmo;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
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
