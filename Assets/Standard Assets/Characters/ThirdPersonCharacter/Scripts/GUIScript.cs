using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    
    public Texture t1;
    public Texture t1_1;
    public Texture t2;
    public Texture Red;
    public Texture Black;
    public Texture Revolver;
    public Texture Shotgun;
    Transform log;
    Transform log2;
    Transform boss;
    bool bossLevelActive = false;
	// Use this for initialization
	void Start () {
        log = GameObject.Find("bosslevel/BossPlatform/BossLog1").transform;
        log2 = GameObject.Find("bosslevel/BossPlatform/BossLog2").transform;
        boss = GameObject.Find("bosslevel/Brute").transform;
	}
    void OnGUI()
    {
        

        GUI.DrawTexture(new Rect(-50, Screen.height * 0.75f, 300, 150), t1_1, ScaleMode.ScaleToFit);
        GUI.BeginGroup(new Rect(-50, Screen.height * 0.75f + GetComponent<ThirdPersonCharacter>().health * 1.5f*(-1)+150, 300, 150));
        GUI.DrawTexture(new Rect(0, GetComponent<ThirdPersonCharacter>().health * 1.5f-150, 300, 150), t2, ScaleMode.ScaleToFit);
        GUI.EndGroup();

        if(bossLevelActive==true&&(log.GetComponent<PillarScript>().getCurrentHP()>0||log2.GetComponent<PillarScript>().getCurrentHP()>0))
        {
            
            GUI.DrawTexture(new Rect(Screen.width * 0.5f-150, Screen.height * 0.02f, 300, 20), Black);
            GUI.DrawTexture(new Rect(Screen.width * 0.5f + 1-149, Screen.height * 0.02f + 1, 298*(log.GetComponent<PillarScript>().getCurrentHP()/log.GetComponent<PillarScript>().HP), 18), Red);

            GUI.DrawTexture(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.06f, 300, 20), Black);
            GUI.DrawTexture(new Rect(Screen.width * 0.5f + 1 - 149, Screen.height * 0.06f + 1, 298 * (log2.GetComponent<PillarScript>().getCurrentHP() / log2.GetComponent<PillarScript>().HP), 18), Red);
        }
        if (bossLevelActive == true && !(log.GetComponent<PillarScript>().getCurrentHP() > 0 || log2.GetComponent<PillarScript>().getCurrentHP() > 0))
        {

            GUI.DrawTexture(new Rect(Screen.width * 0.5f - 300, Screen.height * 0.02f, 600, 20), Black);
            GUI.DrawTexture(new Rect(Screen.width * 0.5f + 1 - 299, Screen.height * 0.02f + 1, 598 * (boss.GetComponent<BossController>().getCurrentHP() / 500), 18), Red);

        }
    }
    public void ActivateBossLevel()
    {
        bossLevelActive = true;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
