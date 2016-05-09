using System;
using System.Collections;
using UnityEngine;


public enum Type
{
    Melee, Revolver
}
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
        AiController controller;
        Animator m_Animator;
        bool stop = true;
        public Type Typ;
        public Transform revolver;
        public Transform bullet;
        NavMeshObstacle obstacle;
        // Use this for initialization
        private void Start()
        {
            if(Typ==Type.Melee)
            {
                revolver.gameObject.SetActive(false);
            }
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            obstacle = GetComponent<NavMeshObstacle>();
            character = GetComponent<ThirdPersonCharacter>();
            controller = GetComponent<AiController>();
	        agent.updateRotation = false;
	        agent.updatePosition = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }


        // Update is called once per frame
        private void Update()
        {
            
          
            if (target != null)
            {
                agent.SetDestination(target.position);
                
                //making them obstacles when they're attacking
                if ((target.position - transform.position).sqrMagnitude < Mathf.Pow(agent.stoppingDistance, 1.8f))
                {
                    // If the agent is in attack range, become an obstacle and
                    // disable the NavMeshAgent component
                    obstacle.enabled = true;
                    agent.enabled = false;
                }
                else {
                    // If we are not in range, become an agent again
                    obstacle.enabled = false;
                    agent.enabled = true;
                }
                
                if (controller.HP>0)
                {
                    transform.LookAt(target);
                    transform.eulerAngles = new Vector3(
                            0,
                            transform.eulerAngles.y,
                            0
                            );

                }
                UpdateAnimator();
                /*AiController Script = character.GetComponent<AiController>();
                if (controller.HP > 0)
                {*/
                    //transform.LookAt(target);
                /*}*/

                //m_Animator.SetFloat("Forward", 0, 0.1f, Time.deltaTime);

                // use the values to move the character
                /*character.Move(agent.desiredVelocity, false, false);*/
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                //character.Move(Vector3.zero, false, false);
            }

        }
        public void UpdateAnimator()
        {
            if (Typ==Type.Melee)
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
            if (Typ == Type.Revolver)
            {


                if (agent.remainingDistance > 15)
                {


                    StartCoroutine(wait());
                    GetComponent<Animator>().SetFloat("Forward", 1);
                    GetComponent<Animator>().SetBool("IsShooting", false);

                }
                else
                {
                    GetComponent<Animator>().SetFloat("Forward", 0);
                    GetComponent<Animator>().SetBool("IsShooting", true);
                }
            }

        }
       public void shoot()
        {
            Transform newBullet = (Transform)Instantiate(bullet, transform.position + transform.forward + new Vector3(0, 1, 0), transform.rotation * Quaternion.Euler(0, 90, 90));
            
           newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200000);
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        IEnumerator wait()
        {
            stop = false;
            yield return new WaitForSeconds(1);
            stop = true;
        }
    }

