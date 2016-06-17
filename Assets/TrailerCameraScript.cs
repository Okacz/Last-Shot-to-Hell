using UnityEngine;
using System.Collections;

public class TrailerCameraScript : MonoBehaviour {

    public Transform dude;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.RotateAround(dude.position, new Vector3 (0, 1, 0), 0.1f);
	}
}
