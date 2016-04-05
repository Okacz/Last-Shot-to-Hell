using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider a)
    {
        if(a.tag=="Player")
        {
            gameObject.SetActive(false);
        }
    }
}
