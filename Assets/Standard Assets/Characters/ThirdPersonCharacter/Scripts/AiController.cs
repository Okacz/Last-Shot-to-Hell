using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {


    public Transform target;
    public Transform enemy;
    bool dead = false;
    public int HP = 40;
    //int chase = 1;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        foreach (CapsuleCollider a in GetComponentsInChildren<CapsuleCollider>())
        {
            a.enabled = false;
        }
        foreach (BoxCollider a in GetComponentsInChildren<BoxCollider>())
        {
            a.enabled = false;
        }
        foreach (Rigidbody a in GetComponentsInChildren<Rigidbody>()) {
            a.freezeRotation = true;
            a.isKinematic = true;
     }
        GetComponent<CapsuleCollider>().enabled = true;
        //GetComponent<BoxCollider>().enabled = true;
        //GetComponent<Rigidbody>().isKinematic = false;
	}
	
	// Update is called once per frame
	void Update () {
       


    }


    
    void TakeDamage(int damage)
    {
        HP -= damage;
    }
    void OnTriggerEnter(Collider a)
    {
        if(a.name=="KickingFoot")
        {
            if(target.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
            GetComponent<RagdollizationScript>().Ragdollize(a, 10);
        }
        if(a.tag=="Bullet")
        {
            //GetComponent<Animator>().SetTrigger("IsHit");
           TakeDamage(20);
            foreach (ParticleSystem b in GetComponentsInChildren<ParticleSystem>())
            {

                Quaternion neededRotation = Quaternion.LookRotation(a.transform.position - b.transform.position);
                b.transform.rotation = a.transform.rotation * Quaternion.Euler(90, 0, 0);
                b.Play();
            }
            if(!dead&&HP<=0)
            {
                
                GetComponent<RagdollizationScript>().Ragdollize(a, 4);
                dead = true;
                
            }
            
            
        }
        /*if(a.tag=="Cactus")
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
        }*/
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
