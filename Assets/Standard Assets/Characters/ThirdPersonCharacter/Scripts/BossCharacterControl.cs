using System;
using System.Collections;
using UnityEngine;



    public class BossCharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
        BossController controller;
        Animator m_Animator;
        bool stop = true;
        public Transform pickaxe;
        public Transform dynamite;
        public Transform bullet;
        bool isDynamiteOnCD = false;
        private int stage;
        float speed;
        Quaternion newrotation = Quaternion.Euler(0, 180, 0);
        NavMeshObstacle obstacle;
        // Use this for initialization
        private void Start()
        {
            
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            obstacle = GetComponent<NavMeshObstacle>();
            character = GetComponent<ThirdPersonCharacter>();
            controller = GetComponent<BossController>();
	        agent.updateRotation = false;
	        agent.updatePosition = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            obstacle.enabled = false;
            agent.acceleration = 1000;
            agent.autoBraking = false;
            agent.angularSpeed = 1000;
            stage = 1;
            if(this.name.StartsWith("RagDoll"))
            {
                agent.speed = 4;
            }
            speed = agent.speed;
        }
        public void setStage(int a)
        {
            stage = a;
        }

        // Update is called once per frame
        private void Update()
        {


            
            if (target != null)
            {
                if(agent.isActiveAndEnabled==true)
                agent.SetDestination(target.position);
                
                
                UpdateAnimator();
                if (controller.HP > 0)
                {
                    transform.LookAt(target);
                    transform.eulerAngles = new Vector3(
                            0,
                            transform.eulerAngles.y,
                            0
                            );

                }
                
            }
            else
            {
                
            }

        }
        void ThrowDynamite()
        {
            Transform newDynamite = (Transform)Instantiate(dynamite, transform.position + transform.forward, transform.rotation * Quaternion.Euler(0, 90, 90));
            float power = Vector3.Distance(target.position, transform.position);
            newDynamite.GetComponent<Rigidbody>().AddForce(transform.forward * 70 * power);
            //GetComponent<Animator>().SetBool("IsPunching", false);
            
        }
        IEnumerator DynamiteCD()
        {
            //GetComponent<Animator>().SetBool("IsPunching", false);
            isDynamiteOnCD = true;
            yield return new WaitForSeconds(3);
            isDynamiteOnCD = false;
            
        }
        
        public void UpdateAnimator()
        {
            if (GetComponentInParent<LevelScript>().checkIfStarted() == true)
            {


                if (target.GetComponent<ThirdPersonCharacter>().health > 0 && target != null)
                {
                    GetComponent<Animator>().SetBool("IsPlayerDead", false);
                    if (stage == 1)
                    {
                        pickaxe.gameObject.SetActive(false);
                        if (isDynamiteOnCD == false)
                        {
                            agent.speed = 0;
                            StartCoroutine(DynamiteCD());
                            GetComponent<Animator>().SetFloat("Forward", 0);
                            GetComponent<Animator>().SetBool("IsPunching", true);
                            
                            ThrowDynamite();
                        }
                        else
                        {
                            GetComponent<Animator>().SetBool("IsPunching", false);
                        }
                    }
                    if (stage == 2)
                    {
                        pickaxe.gameObject.SetActive(true);
                        pickaxe.GetComponent<BoxCollider>().enabled = true;
                        if (agent.remainingDistance > 1.8)
                        {
                            if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
                            {
                                agent.speed = 6;

                            }
                            StartCoroutine(wait());
                            GetComponent<Animator>().SetFloat("Forward", 1);
                            GetComponent<Animator>().SetBool("IsShooting", false);

                        }
                        else
                        {
                            agent.speed = 2;
                            GetComponent<Animator>().SetFloat("Forward", 0);
                            GetComponent<Animator>().SetBool("IsShooting", true);
                        }
                    }

                }
                else
                {
                    GetComponent<Animator>().SetFloat("Forward", 0);
                    GetComponent<Animator>().SetBool("IsShooting", false);
                    GetComponent<Animator>().SetBool("IsPunching", false);
                    GetComponent<Animator>().SetBool("IsPlayerDead", true);
                    agent.ResetPath();
                }
            }

        }
       public void shoot()
        {
            /*Transform newBullet = (Transform)Instantiate(bullet, transform.position + transform.forward + new Vector3(0, 1, 0), transform.rotation * Quaternion.Euler(0, 90, 90));
            rifle.GetComponent<AudioSource>().Play();
           newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200000);*/
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

