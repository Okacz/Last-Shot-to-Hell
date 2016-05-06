using UnityEngine;
using System.Collections;

public class EnemyMeleeAttack : MonoBehaviour {

    public NavMeshAgent agent { get; private set; }
    bool stop = true;
    public Transform target;
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponentInChildren<NavMeshAgent>();
    }
    public void Update()
    {
        if (agent.remainingDistance > 1.8)
        {


            StartCoroutine(wait());
            GetComponent<Animator>().SetFloat("Forward", 1);
            GetComponent<Animator>().SetBool("IsPunching", false);

        }
        else
        {
            GetComponent<Animator>().SetFloat("Forward", 0);
            GetComponent<Animator>().SetBool("IsPunching", true);
        }
       

    }
    IEnumerator wait()
    {
        stop = false;
        yield return new WaitForSeconds(1);
        stop = true;
    }
}
