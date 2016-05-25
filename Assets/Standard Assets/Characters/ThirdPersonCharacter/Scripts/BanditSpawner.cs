using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanditSpawner : MonoBehaviour {

    public Transform Bandit;
    public int Amount;
    public int TimeOfActivation;
     List<Transform> listaBandytów=new List<Transform>();
     bool hasAllSpawned = false;
     bool isDone = false;
	void Start () {
        transform.FindChild("Cube").gameObject.SetActive(false);
	
	}
	public bool checkIfDone()
    {
        return isDone;
    }
	// Update is called once per frame
	void Update () {
	
        if(hasAllSpawned==true&&isDone==false)
        {
            bool arealldead = true;
            foreach(Transform bandit in listaBandytów)
            {
                if (bandit.GetComponent<Animator>().enabled==true)
                {
                    arealldead = false;
                }
            }
            if(arealldead==true)
            {
                isDone = true;
                print("Done");
            }
        }
        
        
	}
    public void SpawnBandits()
    {
        StartCoroutine(spawnBandits());
    }
    public IEnumerator spawnBandits()
    {
        for (int i = 0; i < Amount; i++)
        {

        Transform bandit1 = (Transform)Instantiate(Bandit, this.transform.position, this.transform.rotation);
            if(i%2==0)
            {
                bandit1.GetComponent<AICharacterControl>().Typ = Type.Revolver;
            }
            else
            {
                bandit1.GetComponent<AICharacterControl>().Typ = Type.Melee;
            }
            print("instantiated");
            listaBandytów.Add(bandit1);
            print("added");
            yield return new WaitForSeconds(1);
        print("spawned");
        }
        hasAllSpawned = true;
    }
    
}
