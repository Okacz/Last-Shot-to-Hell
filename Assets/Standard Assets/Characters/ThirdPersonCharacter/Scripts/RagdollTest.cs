using UnityEngine;
using System.Collections;

public class RagdollTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Rigidbody a in GetComponentsInChildren<Rigidbody>())
        {
            a.freezeRotation = true;
            a.isKinematic = true; ;
        }
	}
    
    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
    }
    void Enable()
    {
        
        }
	// Update is called once per frame
	void Update () {
	

        if(Input.GetKeyDown(KeyCode.H))
        {
            if(GetComponent<Animator>().enabled==true)
            {

            GetComponent<Animator>().enabled = false;
            foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
            {
                b.freezeRotation = false;
                b.isKinematic = false;


            }
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
            foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
            {
                b.enableProjection = true;


            }
            
            }
            else
            {
                foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
                {
                    b.freezeRotation = true;
                    b.isKinematic = true;

                    
                }
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Animator>().enabled = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Invoke("Enable", 1);
                GetComponent<CapsuleCollider>().enabled = true;
                /*foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
                {
                    b.enableProjection = false;


                }*/
            
            }



            /*if (GetComponent<Rigidbody>().isKinematic == true)
            {
                foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
                {
                    b.freezeRotation = true;
                    b.isKinematic = true;


                }
                GetComponent<Rigidbody>().isKinematic = false;
            }*/
        }
	}
}
