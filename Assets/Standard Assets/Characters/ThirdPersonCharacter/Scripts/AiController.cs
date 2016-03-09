using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {



    bool dead = false;
    public int HP = 100;
	// Use this for initialization
	void Start () {


        
        foreach (Rigidbody a in GetComponentsInChildren<Rigidbody>()) {
            a.freezeRotation = true;
            a.isKinematic = true; ;
     }
	}
	
	// Update is called once per frame
	void Update () {
	

        
	}
    void OnTriggerEnter(Collider a)
    {
        if(a.tag=="Bullet")
        {
            //GetComponent<Animator>().SetTrigger("IsHit");
            HP -= 20;
            foreach (ParticleSystem b in GetComponentsInChildren<ParticleSystem>())
            {

                Quaternion neededRotation = Quaternion.LookRotation(a.transform.position - b.transform.position);
                b.transform.rotation = a.transform.rotation * Quaternion.Euler(90, 0, 0);
                b.Play();
                print("B " + b.transform.rotation);
            }
            if(!dead&&HP<=0)
            {
                
                GetComponent<Animator>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
                {
                    b.freezeRotation = false;
                    b.isKinematic = false ;
                }
                GetComponent<Rigidbody>().AddForce((a.transform.up+new Vector3(0, 0.5f, 0))*5000);
               
                
                
                
                dead = true;
                StartCoroutine(Wait(3));
                
            }
            
            
        }
        if(a.tag=="Cactus")
        {
            print("walnął w kaktusa");
            if(dead)
            {
                foreach (ParticleSystem b in GetComponentsInChildren<ParticleSystem>())
                {

                    Quaternion neededRotation = Quaternion.LookRotation(a.transform.position - b.transform.position);
                    b.transform.rotation = a.transform.rotation * Quaternion.Euler(90, 0, 0);
                    b.Play();
                    print("B " + b.transform.rotation);
                }

                
                foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
                {

                    b.isKinematic = true;
                    b.freezeRotation = true;
                    
                }
                
            }
        }
    }
    IEnumerator Wait (float duration)
    {
        print("start");
        yield return new WaitForSeconds(duration);
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {

            b.isKinematic = true;
            b.freezeRotation = true;
        }
        print("stop");
    }
}
