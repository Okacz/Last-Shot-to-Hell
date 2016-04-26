using UnityEngine;
using System.Collections;
using UnityEditor;
public class RagdollTest : MonoBehaviour {

	// Use this for initialization
    public GameObject enemyPrefab;
	void Start () {
        /*foreach (Rigidbody a in GetComponentsInChildren<Rigidbody>())
        {
            a.freezeRotation = true;
            a.isKinematic = true; ;
        }*/
        GetComponent<Rigidbody>().freezeRotation = false;
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
        //print(GetComponent<ConstantForce>());
        if(Input.GetKeyDown(KeyCode.O))
        {
            foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
            {
                b.detectCollisions = true;
                //b.useGravity = false;
                //b.isKinematic = true;
                //b.velocity = Vector3.zero;
                if (b.name == "Spine1")
                {

                }

            }
        }
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
            transform.GetComponent<RagdollizationScript>().Ragdollize();
               
            }
            else
            {
                //PrefabUtility.ResetToPrefabState(this);
                transform.GetComponent<RagdollizationScript>().Unragdollize();
                transform.GetComponent<AICharacterControl>().enabled = true;
                transform.GetComponent<AICharacterControl>().target = GameObject.FindGameObjectWithTag("Player").transform;
                transform.GetComponent<NavMeshAgent>().ResetPath();
                print(GameObject.FindGameObjectWithTag("Player").name);
                     //GameObject clone =  (GameObject)Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
                /*a.GetComponent<AICharacterControl>().target = GameObject.FindGameObjectWithTag("Player").transform;
                a.GetComponent<AiController>().HP = 40;*/
                //Destroy(this.gameObject);
                
                
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
