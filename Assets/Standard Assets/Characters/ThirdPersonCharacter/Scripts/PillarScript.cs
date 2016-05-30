using UnityEngine;
using System.Collections;

public class PillarScript : MonoBehaviour {
    public float HP;
    float currentHP;
	// Use this for initialization
	void Start () {
        currentHP = HP;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider c)
    {
        if (c.tag=="Bullet"&&currentHP>0)
        {
            currentHP = currentHP - 10;
            print("pillar "+ currentHP);
            if(currentHP<=0)
            {
                GetComponent<Rigidbody>().isKinematic=false;
                GetComponent<Rigidbody>().AddExplosionForce(-10000, c.transform.position, 100);
                GetComponent<CapsuleCollider>().radius = 0.25f;
            }
        }
    }
    public float getCurrentHP()
    {
        return currentHP;
    }
    void Update()
    {
        
    }
}
