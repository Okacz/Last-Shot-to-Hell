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
                col.gameObject.SendMessage("Ragdollize");
            }
        }
        print("cjk cd");
        
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
    
}
