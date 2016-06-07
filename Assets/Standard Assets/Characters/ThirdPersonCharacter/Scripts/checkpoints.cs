using UnityEngine;
using System.Collections;

public class checkpoints : MonoBehaviour {

    public GameObject Spawn;

    public void OnTriggerEnter(Collider a)
    {
        if (a.tag == "Player")
        {
            GameObject playa = GameObject.Find("PlayerCharacter");
            ThirdPersonCharacter skrypt = playa.GetComponent<ThirdPersonCharacter>();
            skrypt.Spawnpoint = Spawn.transform.position;
        }
    }
}
