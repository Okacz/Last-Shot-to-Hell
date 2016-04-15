using UnityEngine;
using System.Collections;

public class RagdollTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*foreach (Rigidbody a in GetComponentsInChildren<Rigidbody>())
        {
            a.freezeRotation = true;
            a.isKinematic = true; ;
        }*/
        GetComponent<Rigidbody>().isKinematic = false;
	}
    
    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
    }
    void Enable()
    {
        
        }
    void unfreezePosition()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
    void freezePosition()
    {

        if(Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            //UnityEditor.PrefabUtility.ResetToPrefabState(this.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
        unfreezePosition();
        freezePosition();;
        print(GetComponent<ConstantForce>());
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
            {
                if (b.name == "Pelvis")
                {
                    b.freezeRotation = true;
                    b.isKinematic = true;
                }


            }
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(GetComponent<Animator>().enabled==true)
            {
                GetComponent<NavMeshAgent>().enabled = false;
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
         //       b.enableProjection = true;


            }
            
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(0, 10, 0);   
                GetComponent<NavMeshAgent>().enabled = true;
                foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
                {
                    b.freezeRotation = true;
                    b.isKinematic = true;
                    b.velocity = Vector3.zero;
                    
                }
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Animator>().enabled = true;
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Invoke("Enable", 1);
                
                GetComponent<CapsuleCollider>().enabled = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
                {
                    b.enableProjection = false;


                }
                GetComponent<AICharacterControl>().enabled = false;
                
            
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
