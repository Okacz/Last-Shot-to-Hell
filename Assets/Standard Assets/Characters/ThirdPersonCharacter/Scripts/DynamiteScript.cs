using UnityEngine;
using System.Collections;

public class DynamiteScript : MonoBehaviour {

    public float lifetime;
    public GameObject explosion;
    void Start()
    {
        StartCoroutine(Eksplozja());
    }
    
    IEnumerator Eksplozja()
    {

        yield  return new WaitForSeconds(1.5f);
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, 7);
        print("cjk");
        foreach (Collider col in objectsInRange)
        {

            if (col.transform.name.StartsWith("RagDollBitch") || col.transform.name.StartsWith("BanditProper") || col.transform.name.StartsWith("Fat"))
            {
                col.gameObject.GetComponent<AiController>().HP = 0;
                print(col.transform.name);
                object[] tempStorage = new object[2];
                tempStorage[0]=transform.position;
                tempStorage[1]=1000000;
                col.gameObject.GetComponent<RagdollizationScript>().Ragdollize(transform.position, 10000f);
            }
        }
        print("cjk cd");
        
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
    
}
