using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public GameObject DestroyedObject;



    int hp = 100;
    void OnTriggerEnter(Collider c)
    {
        print(c.name);
        if (c.name=="Bullet(Clone)"||c.name=="EnemyBullet(Clone)")
        {
            hp = hp - 25    ;
            if(hp<=0)
            {
            DestroyIt();
            }
        }
    }
	
		void DestroyIt(){
		if(DestroyedObject) {
			Instantiate(DestroyedObject, transform.position, transform.rotation);
		}
		Destroy(gameObject);

	}
}