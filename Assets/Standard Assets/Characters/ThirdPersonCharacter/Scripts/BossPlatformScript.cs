using UnityEngine;
using System.Collections;

public class BossPlatformScript : MonoBehaviour {

    public Transform log1;
    public Transform log2;
    public Transform boss;
    Rigidbody log1R;
    Rigidbody log2R;
    private bool isDestroyed=false;
	// Use this for initialization
	void Start () {
        log1R = log1.GetComponent<Rigidbody>();
        log2R = log1.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	    if(log1R.isKinematic==false&&log2R.isKinematic==false&&isDestroyed==false)
        {
            foreach(Transform child in transform)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
            //boss.GetComponent<NavMeshAgent>().enabled = true;
            //boss.GetComponent<Rigidbody>().isKinematic = true;
            boss.GetComponent<BossCharacterControl>().setStage(2);
            boss.GetComponent<RagdollizationScript>().Ragdollize();
            isDestroyed = true;
        }


	}
}
