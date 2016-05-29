using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    
    public Texture t1;
    public Texture t1_1;
    public Texture t2;
	// Use this for initialization
	void Start () {
	}
    void OnGUI()
    {
        

        GUI.DrawTexture(new Rect(0, Screen.height * 0.75f, 300, 150), t1_1, ScaleMode.ScaleToFit);
        GUI.BeginGroup(new Rect(0, Screen.height * 0.75f + GetComponent<ThirdPersonCharacter>().health * 1.5f*(-1)+150, 300, 150));
        GUI.DrawTexture(new Rect(0, GetComponent<ThirdPersonCharacter>().health * 1.5f-150, 300, 150), t2, ScaleMode.ScaleToFit);
        GUI.EndGroup();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
