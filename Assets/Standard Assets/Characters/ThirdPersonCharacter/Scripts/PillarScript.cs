using UnityEngine;
using System.Collections;

public class PillarScript : MonoBehaviour {
    public float HP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider c)
    {
        if (c.tag=="Bullet"&&HP>0)
        {
            HP = HP - 10;
            print("pillar "+ HP);
            if(HP<=0)
            {
                GetComponent<Rigidbody>().isKinematic=false;
                GetComponent<Rigidbody>().AddExplosionForce(-10000, c.transform.position, 100);
                GetComponent<CapsuleCollider>().radius = 0.25f;
            }
        }
    }
    void Update()
    {
        
    }
}
