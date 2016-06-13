﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelScript : MonoBehaviour {
    public bool isStartLevel;
    public bool isBossLevel;
    private bool isFinished = false;
    private bool isStarted = false;
    public List<Transform> Enemies;
    public List<BanditSpawner> BanditSpawners;
    public GameObject Entrance;
    public GameObject Exit;
    public GameObject Trigger;
    public GameObject Player;
    public GameObject AmmoPack;
    public GameObject HealthPack;
    CutsceneScript cutscene;

    int TimeActive;
	void Start ()
    {
        try
        {

        cutscene = GetComponent<CutsceneScript>();
        }
        catch
        {
            cutscene = null;
        }
        TimeActive=0;
        if(!isStartLevel)
        {
            foreach (Transform a in Enemies)
            {
                a.GetComponent<NavMeshAgent>().enabled = false;
                //a.GetComponent<AiController>().target = Player.transform;
                if(a.name!="Brute")
                {
                a.GetComponent<AICharacterControl>().target =null;
                }
                else
                a.GetComponent<BossCharacterControl>().target = null;
            }
        }
        else
        {
            StartCoroutine(PassingTime());
        }
        
        
	}
    public bool checkIfStarted()
    {
        return isStarted;
    }
	public IEnumerator PassingTime()
        {
            while(isFinished!=true)
            {
            yield return new WaitForSeconds(1);
                TimeActive++;
                foreach (BanditSpawner bs in BanditSpawners)
                {
                    if(TimeActive==bs.GetComponent<BanditSpawner>().TimeOfActivation)
                    {
                        bs.GetComponent<BanditSpawner>().SpawnBandits();
                    }
                }
            }
        }
	// Update is called once per frame
	void Update () {
        if(Trigger!=null)
        {
            
            if (Trigger.activeSelf == false&&isStarted==false)
            {
                if (cutscene != null)
                {

                    if (cutscene.hasStarted == false)
                    {
                        cutscene.StartCutscene(5);
                    }
                }
                if (cutscene==null)
                {

                    if(isBossLevel==true)
                    {
                        Player.GetComponent<GUIScript>().ActivateBossLevel();
                    }
                        StartCoroutine(PassingTime());
                    foreach (Transform a in Enemies)
                    {
                        if(a.name!="Brute")
                        a.GetComponent<NavMeshAgent>().enabled = true;
                        //a.GetComponent<AiController>().target = Player.transform;
                        try
                        {
                            a.GetComponent<AICharacterControl>().target = Player.transform;
                        }
                        catch 
                        {
                        }
                        try
                        {
                            a.GetComponent<BossCharacterControl>().target = Player.transform;
                        }
                        catch 
                        {
                        }
                        Entrance.SetActive(true);
                        print("git");
                }
                isStarted = true;
                }
                else
                {
                    if(cutscene.isDone==true)
                    {
                        if (isBossLevel == true)
                        {
                            Player.GetComponent<GUIScript>().ActivateBossLevel();
                        }
                        StartCoroutine(PassingTime());
                        foreach (Transform a in Enemies)
                        {
                            if (a.name != "Brute")
                                a.GetComponent<NavMeshAgent>().enabled = true;
                            //a.GetComponent<AiController>().target = Player.transform;
                            try
                            {
                                a.GetComponent<AICharacterControl>().target = Player.transform;
                            }
                            catch
                            {
                            }
                            try
                            {
                                a.GetComponent<BossCharacterControl>().target = Player.transform;
                            }
                            catch
                            {
                            }
                            Entrance.SetActive(true);
                            print("git");
                        }
                        isStarted = true;
                    }
                }
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
            foreach(BanditSpawner bs in BanditSpawners)
            {
                if (bs.GetComponent<BanditSpawner>().checkIfDone()==false)
                {
                    b = false;
                }
            }
            if (b == true)
            {
                Exit.SetActive(false);
                AmmoPack.SetActive(true);
                HealthPack.SetActive(true);
                isFinished = true;
            }
            
           
        }
        
	}
}
