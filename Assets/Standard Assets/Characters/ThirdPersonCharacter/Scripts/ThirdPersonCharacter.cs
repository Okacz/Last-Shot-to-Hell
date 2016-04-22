using UnityEngine;
using UnityEngine.UI;

	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[SerializeField] float m_JumpPower = 12f;
		[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[SerializeField] float m_GroundCheckDistance = 0.1f;

		Rigidbody m_Rigidbody;
		Animator m_Animator;
		bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
        float m_LeftAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;
		bool m_Crouching;
        bool hasShot=true;
        bool isTwisted = false;
        Vector3 mainCameraPosition;
        Quaternion mainCameraRotation;

        int revolverAmmo = 0;
        int shotgunAmmo = 0;
        int dynamiteAmmo = 0;



        public GameObject weaponPanels;
        public Transform shotgun;
        public Transform rifle;
        public Transform bullet;
        public Transform revolver;
        public Transform dynamite;
        public Transform litDynamite;
        public Camera camera;

        public enum Weapons
        {
            Unarmed = 0,
            Revolver = 1,
            Rifle = 2,
            Shotgun = 3,
            Dynamite = 4
        };
        Weapons currentWeapon;
        void UpdateAmmo()
        {
            foreach (Transform child in weaponPanels.transform)
            {
                
                
                foreach (Transform child1 in child.transform)
                {
                   
                    if(child.name=="ShotgunPanel")
                    {
                        child1.gameObject.GetComponent<Text>().text = "x " + shotgunAmmo.ToString() +"";
                    }
                    if (child.name == "RevolverPanel")
                    {
                        child1.gameObject.GetComponent<Text>().text = "x " + revolverAmmo.ToString() + "";
                        

                    }
                    if (child.name == "DynamitePanel")
                    {
                        string newtext = "x " + dynamiteAmmo;
                        child1.gameObject.GetComponent<Text>().text = newtext;
                    }
                }
            }
            
        }
		void Start()
		{
            weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(true);
            revolverAmmo = 100;
            shotgunAmmo = 10;
            dynamiteAmmo = 10;
            UpdateAmmo();
            currentWeapon = Weapons.Revolver;
            mainCameraPosition = camera.transform.position - transform.position ;
            mainCameraRotation = camera.transform.rotation;
            rifle.gameObject.SetActive(false);
            shotgun.gameObject.SetActive(false);
            dynamite.gameObject.SetActive(false);
			m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;
            m_Animator.SetInteger("Weapon", 1);
			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
            
		}
        int GetEnumValue(bool dir)
        {
            int a = (int)currentWeapon;
            int next=0;
            if (dir == true)
                next = a + 1;
            else
                next = a - 1;

            if (next < 0)
                next = 4;
            if (next > 4)
                next = 0;

            return next;
            
        }
        void ChangeWeapon(int a)
        {
            int gun = a;
            switch (gun)
            {
                case 0: currentWeapon=Weapons.Unarmed; 
                    revolver.gameObject.SetActive(false);
                    rifle.gameObject.SetActive(false);
                    shotgun.gameObject.SetActive(false);
                    m_Animator.SetInteger("Weapon", 0);
                    weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("ShotgunPane").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("DynamitePanel").gameObject.SetActive(false);
                    break;
                case 1: currentWeapon = Weapons.Revolver;
                    revolver.gameObject.SetActive(true);
                    rifle.gameObject.SetActive(false);
                    shotgun.gameObject.SetActive(false);
                    dynamite.gameObject.SetActive(false);
                    m_Animator.SetInteger("Weapon", 1);
                    weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(true);
                    weaponPanels.transform.FindChild("ShotgunPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("DynamitePanel").gameObject.SetActive(false);
                    break;
                case 2: currentWeapon = Weapons.Rifle;
                    revolver.gameObject.SetActive(false);
                    rifle.gameObject.SetActive(true);
                    shotgun.gameObject.SetActive(false);
                    dynamite.gameObject.SetActive(false);
                    m_Animator.SetInteger("Weapon", 2);
                    weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("ShotgunPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("DynamitePanel").gameObject.SetActive(false);
                    break;
                case 3: currentWeapon = Weapons.Shotgun; 
                    revolver.gameObject.SetActive(false);
                    rifle.gameObject.SetActive(false);
                    shotgun.gameObject.SetActive(true);
                    dynamite.gameObject.SetActive(false);
                    m_Animator.SetInteger("Weapon", 3);
                    weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("ShotgunPanel").gameObject.SetActive(true);
                    weaponPanels.transform.FindChild("DynamitePanel").gameObject.SetActive(false);
                    break;
                case 4: currentWeapon = Weapons.Dynamite;
                    revolver.gameObject.SetActive(false);
                    rifle.gameObject.SetActive(false);
                    shotgun.gameObject.SetActive(false);
                    dynamite.gameObject.SetActive(true);
                    m_Animator.SetInteger("Weapon", 4);
                    weaponPanels.transform.FindChild("RevolverPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("ShotgunPanel").gameObject.SetActive(false);
                    weaponPanels.transform.FindChild("DynamitePanel").gameObject.SetActive(true);
                    
                    break;
            }
                
        }

        
        void LookAtCursor()
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit cameraRayHit;
            if (Physics.Raycast(ray, out cameraRayHit))
            {
                Quaternion interpolatedRotation=new Quaternion(0, 0, 0, 0);
                if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bang (shotgun)") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bang (rifle)"))
                {
                    Vector3 targetPosition;
                    if (cameraRayHit.transform.tag != "Enemy")
                    {
                        targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                        Quaternion neededRotation = Quaternion.LookRotation(targetPosition - transform.position);
                        neededRotation *= Quaternion.Euler(0, 50, 0);
                        interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 7);
                        transform.rotation = interpolatedRotation;
                    }
                    else
                    {
                        targetPosition = cameraRayHit.transform.position;
                        Quaternion neededRotation = Quaternion.LookRotation(targetPosition - transform.position);
                        neededRotation *= Quaternion.Euler(0, 50, 0);
                        interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 7);
                        transform.rotation = interpolatedRotation;
                    }



                    
                }
                else
                {
                    Vector3 targetPosition;
                    if(cameraRayHit.transform.tag!="Enemy")
                    {
                        targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                        Quaternion neededRotation = Quaternion.LookRotation(targetPosition - transform.position);
                        interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 7);
                        transform.rotation = interpolatedRotation;
                    }
                    else
                    {
                        targetPosition = cameraRayHit.transform.position;
                        Quaternion neededRotation = Quaternion.LookRotation(targetPosition - transform.position);
                        interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 7);
                        transform.rotation = interpolatedRotation;
                    }
                    
                }
                
            }
        }
        void BangEnded()
        {
            hasShot = false;
            if(currentWeapon==Weapons.Revolver)
            {
                revolverAmmo--;
            }
            if (currentWeapon == Weapons.Shotgun)
            {
                shotgunAmmo--;
            }
            UpdateAmmo();
        }
        void Update()
        {
            camera.transform.position = transform.position + mainCameraPosition;
            LookAtCursor(); //Kod na patrzenie w kierunku kursora, usun¹æ dla sterowania bez myszki
            
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bang (revolver)"))
            {
                if(hasShot==false)
                {
                    revolver.GetComponent<AudioSource>().Play();
                    Transform newBullet = (Transform)Instantiate(bullet, revolver.transform.position+transform.forward, transform.rotation*Quaternion.Euler(0, 90, 90));
                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200000);
                    hasShot = true;
                }
                
            }
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bang (shotgun)"))
            {
                if (hasShot == false)
                {
                    shotgun.GetComponent<AudioSource>().Play();
                    for(int i=0; i<9; i++)
                    {
                        
                        Quaternion zmiana=Quaternion.Euler(0, -18+(i*5), 0);
                        Vector3 vzmiana = new Vector3(0, -18 + (i * 5), 0);
                        Transform newBullet = (Transform)Instantiate(bullet, shotgun.transform.position + shotgun.transform.forward, transform.rotation*Quaternion.Euler(0, -65, 0) *zmiana* Quaternion.Euler(0, 90, 90));
                        //newBullet.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        newBullet.GetComponent<Rigidbody>().mass = 400;
                        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.up * 500000);
                        
                    }
                    
                    hasShot = true;
                }

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if(camera.transform.position!=new Vector3(-4, -40, -10))
                {
                Vector3 targetPosition = new Vector3(-4, -40, -10);
                camera.transform.position = targetPosition;
                Quaternion targetRotation = Quaternion.Euler(new Vector3(89, -90, 0));
                camera.transform.rotation = targetRotation;
                }
                else
                {
                camera.transform.position = mainCameraPosition;
               
                camera.transform.rotation = mainCameraRotation;
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("scena1");
            }
            if (Input.GetKey(KeyCode.E))
            {
                m_Animator.SetBool("Punching", true);
                if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
                {
                    
                    m_Animator.SetBool("LeftPunch", !m_Animator.GetBool("LeftPunch"));
                }
                
                
            }
            else
                /*if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))*/
            {
                m_Animator.SetBool("Punching", false);

            }
            if(Input.GetButton("Fire1")&&currentWeapon!=Weapons.Dynamite)
            {
                if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
                {
                    m_Animator.SetBool("Shooting", true);
                    
                }
                if((currentWeapon==Weapons.Shotgun)&&isTwisted==false)
                {
                    
                    isTwisted = true;
                }
            }
            if (Input.GetButtonDown("Fire1")&&currentWeapon==Weapons.Dynamite)
            {
                
                    m_Animator.SetBool("Shooting", true);

                
            }
            if (Input.GetButtonUp("Fire1"))
            {

                m_Animator.SetBool("Shooting", false);


            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0 && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                if(Input.GetAxis("Mouse ScrollWheel")>0f)
                {
                    ChangeWeapon( GetEnumValue(true));
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                   ChangeWeapon(  GetEnumValue(false));
                }
            }
        }
        void ThrowDynamite()
        {
            Transform newDynamite = (Transform)Instantiate(litDynamite, dynamite.transform.position + transform.forward, transform.rotation * Quaternion.Euler(0, 90, 90));
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit cameraRayHit;
            float power = 0;
            if (Physics.Raycast(ray, out cameraRayHit))
            {
               Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
               power = Vector3.Distance(targetPosition, transform.position);
               
               print("power: "+power);
            }
            newDynamite.GetComponent<Rigidbody>().AddForce(transform.forward * 70*power);

            dynamiteAmmo--;
            UpdateAmmo();
        }
        void CanSeePlayer() {
            
        }
        public void Move(Vector3 move, bool crouch, bool jump)
		{
           






			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, m_GroundNormal);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;
            m_LeftAmount = move.x;
            //m_Rigidbody.velocity = transform.forward * 10;
            //print("movex = " + move.x + " movez =" + move.z);
            //GetComponent<CharacterController>().Move(new Vector3(m_ForwardAmount, 0, m_LeftAmount)*0.1f);
            
			//ApplyExtraTurnRotation();

			// control and velocity handling is different when grounded and airborne:
			if (m_IsGrounded)
			{
				HandleGroundedMovement(crouch, jump);
			}
			else
			{
				HandleAirborneMovement();
			}

			ScaleCapsuleForCrouching(crouch);
			PreventStandingInLowHeadroom();

			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}


		void ScaleCapsuleForCrouching(bool crouch)
		{
			if (m_IsGrounded && crouch)
			{
				if (m_Crouching) return;
				m_Capsule.height = m_Capsule.height / 2f;
				m_Capsule.center = m_Capsule.center / 2f;
				m_Crouching = true;
			}
			else
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength))
				{
					m_Crouching = true;
					return;
				}
				m_Capsule.height = m_CapsuleHeight;
				m_Capsule.center = m_CapsuleCenter;
				m_Crouching = false;
			}
		}

		void PreventStandingInLowHeadroom()
		{
			// prevent standing up in crouch-only zones
			if (!m_Crouching)
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength))
				{
					m_Crouching = true;
				}
			}
		}


		void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
            
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
            m_Animator.SetFloat("Left", m_LeftAmount, 0.1f, Time.deltaTime);
            
			//m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool("Crouch", m_Crouching);
			m_Animator.SetBool("OnGround", m_IsGrounded);
			if (!m_IsGrounded)
			{
				m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
			}

			// calculate which leg is behind, so as to leave that leg trailing in the jump animation
			// (This code is reliant on the specific run cycle offset in our animations,
			// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
			float runCycle =
				Mathf.Repeat(
					m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
            
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
			if (m_IsGrounded)
			{
				m_Animator.SetFloat("JumpLeg", jumpLeg);
			}

			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (m_IsGrounded && move.magnitude > 0)
			{
				m_Animator.speed = m_AnimSpeedMultiplier;
			}
			else
			{
				// don't use that while airborne
				m_Animator.speed = 1;
			}
		}


		void HandleAirborneMovement()
		{
			// apply extra gravity from multiplier:
			Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
			m_Rigidbody.AddForce(extraGravityForce);

			m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
		}


		void HandleGroundedMovement(bool crouch, bool jump)
		{
			// check whether conditions are right to allow a jump:
			if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
			{
				// jump!
				m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
				m_IsGrounded = false;
				m_Animator.applyRootMotion = false;
				m_GroundCheckDistance = 0.1f;
			}
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (m_IsGrounded && Time.deltaTime > 0)
			{

                Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;
                
				// we preserve the existing y part of the current velocity.
				v.y = m_Rigidbody.velocity.y;
				m_Rigidbody.velocity = v;
                
			}
		}

        
		void CheckGroundStatus()
		{
			RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
			{
				m_GroundNormal = hitInfo.normal;
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
			}
			else
			{
				m_IsGrounded = false;
				m_GroundNormal = Vector3.up;
				m_Animator.applyRootMotion = false;
			}
		}
	}

