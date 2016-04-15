using System;
using System.Collections;
using UnityEngine;


    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    [RequireComponent(typeof(Animator))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
        AiController controller;
        Animator m_Animator;
        bool stop = true;
        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            controller = GetComponent<AiController>();
	        agent.updateRotation = false;
	        agent.updatePosition = true;

            
        }


        // Update is called once per frame
        private void Update()
        {
            
          
            if (target != null)
            {
                agent.SetDestination(target.position);

                if(controller.HP>0)
                {
                    transform.LookAt(target);

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
                character.Move(Vector3.zero, false, false);
            }

        }
        public void UpdateAnimator()
        {

            if (agent.remainingDistance > 1.8)
            {
                if (stop == true)
                {

                    StartCoroutine(wait());
                    GetComponent<Animator>().SetFloat("Forward", 1);
                    GetComponent<Animator>().SetBool("IsPunching", false);
                }
            }
            else
            {
                GetComponent<Animator>().SetFloat("Forward", 0);
                GetComponent<Animator>().SetBool("IsPunching", true);
            }
           
            
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

