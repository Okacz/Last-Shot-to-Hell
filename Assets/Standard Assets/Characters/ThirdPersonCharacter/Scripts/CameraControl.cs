using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Transform camera;
    Vector3 mainCameraPosition;
	// Use this for initialization
	void Start () {
        mainCameraPosition = camera.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<ThirdPersonCharacter>().health > 0&&GetComponent<Animator>().enabled==true)
        {
            camera.transform.position = transform.position + mainCameraPosition;
        }
        else
        {
            camera.transform.position = transform.FindChild("Cowboy").FindChild("CG").FindChild("Pelvis").FindChild("Spine").transform.position + mainCameraPosition;
        }
	}
}
