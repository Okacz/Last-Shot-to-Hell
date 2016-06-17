using UnityEngine;
using System.Collections;

public class checkpoints : MonoBehaviour {

    public GameObject Spawn;
    public int Numer;

    public void OnTriggerEnter(Collider a)
    {
        if (a.tag == "Player")
        {
            GameObject playa = GameObject.Find("PlayerCharacter");
            ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
            skrypt.Spawnpoint = Spawn.transform.position;
            PlayerPrefs.SetFloat("x", Spawn.transform.position.x);
            PlayerPrefs.SetFloat("y", Spawn.transform.position.y);
            PlayerPrefs.SetFloat("z", Spawn.transform.position.z);
            PlayerPrefs.Save();
            playa.GetComponent<ThirdPersonCharacter>().spawnnumber = Numer;
        }
    }
}
