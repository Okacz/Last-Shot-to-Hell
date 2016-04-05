using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelScript : MonoBehaviour {
    public bool isStartLevel;
    private bool isFinished = false;
    private bool isStarted = false;
    public List<Transform> Enemies;
    public GameObject Entrance;
    public GameObject Exit;
    public GameObject Trigger;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        if(!isStartLevel)
        {
            foreach (Transform a in Enemies)
            {
                a.GetComponent<NavMeshAgent>().enabled = false;
                //a.GetComponent<AiController>().target = Player.transform;
                a.GetComponent<AICharacterControl>().target =null;
                
            }
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Trigger!=null)
        {
            if (Trigger.activeSelf == false&&isStarted==false)
            {
                foreach (Transform a in Enemies)
                {
                    a.GetComponent<NavMeshAgent>().enabled = true;
                    //a.GetComponent<AiController>().target = Player.transform;
                    a.GetComponent<AICharacterControl>().target = Player.transform;
                    Entrance.SetActive(true);
                    print("git");
                }
                isStarted = true;
            }
        }
        
        if(isFinished==false)
        {
            bool b = true;
            foreach (Transform a in Enemies)
            {
                if (a.GetComponent<Animator>().enabled == true)
                {
                    b = false;
                }
            }
            if (b == true)
            {
                Exit.SetActive(false);
                isFinished = true;
            }
            
           
        }
        
	}
}
