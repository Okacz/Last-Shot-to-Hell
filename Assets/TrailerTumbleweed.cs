using UnityEngine;
using System.Collections;

public class TrailerTumbleweed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 2, 2), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
