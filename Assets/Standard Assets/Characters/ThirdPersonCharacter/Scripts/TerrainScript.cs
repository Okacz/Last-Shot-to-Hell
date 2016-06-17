using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {
    public Transform blood;
    bool isCD = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnParticleCollision(GameObject other)
    {
        ParticleCollisionEvent[] collisionEvents=new ParticleCollisionEvent[64];
        other.GetComponent<ParticleSystem>().GetCollisionEvents(this.gameObject, collisionEvents);
        int a=other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize();
        if (collisionEvents.Length < a)
            collisionEvents = new ParticleCollisionEvent[a];
        foreach(ParticleCollisionEvent ev in collisionEvents)
        {
            Vector3 inter = ev.intersection;
        if(isCD==false)
        {
            float range = Random.Range(0.03f, 0.18f);
        Transform blood1 = (Transform)Instantiate(blood, other.transform.position, Quaternion.Euler(0, Random.Range(0, 180), 0));
        blood1.position = new Vector3(inter.x, -47.35f, inter.z);
        blood1.localScale = new Vector3(range, range, range);
        StartCoroutine(waitforcd());
        }
        }

        //Destroy(other);

    }
    IEnumerator waitforcd()
    {
        isCD = true;
        yield return new WaitForSeconds(0.05f);
        isCD = false;
    }
}
