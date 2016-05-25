using UnityEngine;
using System.Collections;

public class RagdollizationScript : MonoBehaviour {
    public void RagdollizePlayer()
    {
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.mass = b.mass * 10000;
        }
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<ThirdPersonCharacter>().enabled = false;
        GetComponent<NavMeshObstacle>().enabled = false;
        GetComponent<ThirdPersonUserControl>().enabled = false;
        GetComponent<Animator>().enabled = false;
        
        StartCoroutine(GetUpPlayer());
        
    }
    public void RagdollizePlayer(Collider aa, float force)
    {
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.mass = b.mass*1000;
        }
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<ThirdPersonCharacter>().enabled = false;
        GetComponent<NavMeshObstacle>().enabled = false;
        GetComponent<ThirdPersonUserControl>().enabled = false;
        GetComponent<Animator>().enabled = false;
        foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
        {
            b.enableProjection = true;
        }
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
           
            if (b.name == "Pelvis" || b.name == "mixamorig:Hips")
            {
                //b.GetComponent<Rigidbody>().AddForce((transform.up + new Vector3(0, 0.5f, 0)) * GetComponent<Rigidbody>().mass * 10000);
                b.GetComponent<Rigidbody>().AddForce(aa.transform.up  * force*1000);
                //b.GetComponent<Rigidbody>().AddExplosionForce(force, aa.transform.position, 100, 1, ForceMode.Impulse);

            }
            
        }
        StartCoroutine(GetUpPlayer());

    }
	public void Ragdollize()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        foreach (CapsuleCollider a in GetComponentsInChildren<CapsuleCollider>())
        {
            a.enabled = true;
        }
        foreach (BoxCollider a in GetComponentsInChildren<BoxCollider>())
        {
            a.enabled = true;
        }

        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            
            b.freezeRotation = false;
            b.isKinematic = false;
            if (b.name == "Spine1")
            {
            
            }
            if (b.name == "EnemyArm")
            {
                b.name = "DeadEnemyArm";
            }
            if (b.name == "FatArm")
            {
                b.name = "DeadFatArm";
            }
            b.mass = b.mass * 1000;
        }
        tag = "Untagged";
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
        {
            b.enableProjection = true;


        }
        GetComponent<AICharacterControl>().target = null;
        GetComponent<AICharacterControl>().enabled = false;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        if(GetComponent<AiController>().HP>0)
        StartCoroutine(GetUp());
    }
    public void Ragdollize(Vector3 aa, float force)
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        foreach (CapsuleCollider a in GetComponentsInChildren<CapsuleCollider>())
        {
            a.enabled = true;
        }
        foreach (BoxCollider a in GetComponentsInChildren<BoxCollider>())
        {
            a.enabled = true;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.freezeRotation = false;
            b.isKinematic = false;

            if (b.name == "Pelvis")
            {
                //b.GetComponent<Rigidbody>().AddForce((transform.up + new Vector3(0, 0.5f, 0)) * GetComponent<Rigidbody>().mass * 10000);
                b.GetComponent<Rigidbody>().AddForce(transform.forward*1000 * force);
                //GetComponent<Rigidbody>().AddExplosionForce(500, aa.transform.position, 10);

                //
            }
            if (b.name == "EnemyArm")
            {
                b.name = "DeadEnemyArm";
            }
            if (b.name == "FatArm")
            {
                b.name = "DeadFatArm";
            }
            b.mass = b.mass * 1000;
        }

        tag = "Untagged";
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
        {
            b.enableProjection = true;


        }
        GetComponent<AICharacterControl>().enabled = false;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        if (GetComponent<AiController>().HP > 0)
            StartCoroutine(GetUp());
    }
    public void Ragdollize(Collider aa, float force)
    {
        
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        foreach (CapsuleCollider a in GetComponentsInChildren<CapsuleCollider>())
        {
            a.enabled = true;
        }
        foreach (BoxCollider a in GetComponentsInChildren<BoxCollider>())
        {
            a.enabled = true;
        }

        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.freezeRotation = false;
            b.isKinematic = false;
            
            if (b.name == "Pelvis"||b.name=="mixamorig:Hips")
            {
                //b.GetComponent<Rigidbody>().AddForce((transform.up + new Vector3(0, 0.5f, 0)) * GetComponent<Rigidbody>().mass * 10000);
                b.GetComponent<Rigidbody>().AddForce(aa.transform.up  * 1000*force);
                //GetComponent<Rigidbody>().AddExplosionForce(500, aa.transform.position, 10);
               
                //
            }
            if(b.name=="EnemyArm")
            {
                b.name = "DeadEnemyArm";
            }
            if (b.name == "FatArm")
            {
                b.name = "DeadFatArm";
            }
            b.mass = b.mass * 1000;
        }
        tag = "Untagged";
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
        {
            b.enableProjection = true;


        }
        GetComponent<AICharacterControl>().enabled = false;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        if (GetComponent<AiController>().HP > 0)
        StartCoroutine(GetUp());
    }
    IEnumerator GetUp()
    {
        
            yield return new WaitForSeconds(3.0f);
            if (GetComponent<AiController>().HP > 0)
            {
            Unragdollize();
            GetComponent<NavMeshAgent>().ResetPath();
            GetComponent<NavMeshAgent>().SetDestination(GetComponent<AICharacterControl>().target.position);
            GetComponent<NavMeshAgent>().enabled = true;
            }
            GetComponent<AICharacterControl>().enabled = true;
    }
    IEnumerator GetUpPlayer()
    {
        print("getting up");
        yield return new WaitForSeconds(1.0f);
        if (GetComponent<ThirdPersonCharacter>().health > 0)
        {
            UnragdollizePlayer();
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            Application.LoadLevel("main_menu");
        }
    }
    public void UnragdollizePlayer()
    {
        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.mass = b.mass / 10000;
        }
        Vector3 position2 = Vector3.zero;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "L Foot")
            {
                position2 = child.position;
            }

        }
        
        transform.position = position2;
        transform.position = new Vector3(transform.position.x, -47.37f, transform.position.z);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<ThirdPersonCharacter>().enabled = true;
        GetComponent<NavMeshObstacle>().enabled = true;
        GetComponent<ThirdPersonUserControl>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
    public void Unragdollize()
    {
        Vector3 position2=Vector3.zero;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "R Foot")
            {
            position2 = child.position;
            }

        }
        transform.position = position2;


        GetComponent<AiController>().HP = 40;
        GetComponent<Animator>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<NavMeshAgent>().updateRotation = false;
        GetComponent<NavMeshAgent>().updatePosition = true;

        foreach (CapsuleCollider a in GetComponentsInChildren<CapsuleCollider>())
        {
            a.enabled = true;
        }
        foreach (BoxCollider a in GetComponentsInChildren<BoxCollider>())
        {
            a.enabled = false;
        }

        foreach (Rigidbody b in GetComponentsInChildren<Rigidbody>())
        {
            b.freezeRotation = true;
            
            if (b.name == "Spine1")
            {

            }

        }
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().detectCollisions = true;
        tag = "Enemy";
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = true;
        foreach (CharacterJoint b in GetComponentsInChildren<CharacterJoint>())
        {
            b.enableProjection = false;
        }
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
