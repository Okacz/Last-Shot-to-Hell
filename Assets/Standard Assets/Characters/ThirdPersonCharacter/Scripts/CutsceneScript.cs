using UnityEngine;
using System.Collections;

public class CutsceneScript : MonoBehaviour {
    public Transform player;
    public bool isDone = false;
    public bool hasStarted = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartCutscene(float time)
    {
        
        print("cutscene started");
        hasStarted = true;
       
        StartCoroutine(player.GetComponent<ThirdPersonCharacter>().restrictMovement(time));
        StartCoroutine(cutsceneTime(time));

    }
    IEnumerator cutsceneTime(float time)
    {
        yield return new WaitForSeconds(time);
        isDone = true;
    }
}
