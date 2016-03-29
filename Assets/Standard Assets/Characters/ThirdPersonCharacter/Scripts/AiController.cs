using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {


    public Transform target;
    bool dead = false;
    public int HP = 100;
    //int chase = 1;

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
                tag = "Untagged";
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                //Destroy(GetComponent<Rigidbody>());
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<CapsuleCollider>().enabled = false;
                //GetComponent<Rigidbody>().freezeRotation = true;
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
                {
                    b.enableProjection = true;
                    
                    
                }
                
                foreach(Transform child in GetComponentsInChildren<Transform>())
                {
                    child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                }
                
                
                
                dead = true;
                //StartCoroutine(Wait(3));
                
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
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
