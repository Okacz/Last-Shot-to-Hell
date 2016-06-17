using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Transform camera;
    Vector3 mainCameraPosition;
	// Use this for initialization
	void Start () {
        mainCameraPosition = transform.position;
	}
	public void setPosition(float x, float y, float z)
    {
        mainCameraPosition = new Vector3(x, y, z);
        print("position set");
    }
	// Update is called once per frame
	void Update () {
        if (GetComponent<ThirdPersonCharacter>().health > 0&&GetComponent<Animator>().enabled==true)
        {
            camera.transform.position = new Vector3(transform.position.x-5.81f, transform.position.y+5.58f, transform.position.z-0.5f);
        }
        else
        {
            Vector3 pos1 = transform.FindChild("Cowboy").FindChild("CG").FindChild("Pelvis").FindChild("Spine").transform.position;
            camera.transform.position = new Vector3(pos1.x - 5.81f, pos1.y + 5.58f, pos1.z - 0.5f);
        }
	}
}
