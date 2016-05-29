using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    float health;
    public Texture t1;
    public Texture t2;
	// Use this for initialization
	void Start () {
        health = GetComponent<ThirdPersonCharacter>().health;
	}
    void OnGUI()
    {
        GUI.VerticalScrollbar(new Rect(0, Screen.height - 100, 20, 150), 0, GetComponent<ThirdPersonCharacter>().health, 100, 0);
        GUI.skin.verticalScrollbar.fixedWidth = 20;
        /*GUI.DrawTexture(new Rect(200, Screen.height - 100, 100, 100), t1);
        GUI.DrawTexture(new Rect(200, (((Screen.height - 100) * 2 + t1.height) / 2) - (t1.height*GetComponent<ThirdPersonCharacter>().health/100)/2, 100, GetComponent<ThirdPersonCharacter>().health), t2, ScaleMode.ScaleAndCrop);

        GUI.DrawTexture(new Rect(300, Screen.height - 100, 100, 100), t1);
        GUI.DrawTexture(new Rect(300, Screen.height - 100, 100, GetComponent<ThirdPersonCharacter>().health), t2, ScaleMode.ScaleToFit);

        GUI.DrawTexture(new Rect(400, Screen.height - 100, 100, 100), t1);
        GUI.DrawTexture(new Rect(400, Screen.height - 100, 100, GetComponent<ThirdPersonCharacter>().health), t2, ScaleMode.StretchToFill);
        */
    }
	// Update is called once per frame
	void Update () {
	
	}
}
