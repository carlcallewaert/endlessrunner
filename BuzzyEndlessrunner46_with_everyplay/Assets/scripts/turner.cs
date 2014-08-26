using UnityEngine;
using System.Collections;
public class turner : MonoBehaviour {
	
	
	protected Animator animator;
	float targetTurn = 90;
	bool doTurn = false;
	bool Jump = false;

	
	
	Quaternion targetRotation;
	
	void Start()
	{
		animator = GetComponent<Animator>();

	}
	


	void Turnleft (){
		doTurn = true;
		targetTurn = -90;

	}

	void Turnright(){
		doTurn = true;
		targetTurn = 90;
	}

	void Jumpit(){
		Jump = true;
	}


	void Carl(){
		Destroy(gameObject);
	}

	//void OnCollisionEnter(Collision collision) {
	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "Deadzone")
		{
			animator.SetBool("Died", true);
			//Application.LoadLevel("001");

			// Stop Recording and Share Everplay!!!!

			//Everyplay.StopRecording();
			//Everyplay.SetMetadata("score", score) 
			//Everyplay.PlayLastRecording();

		}
		
	}



	void Update()
	{
		
		animator.SetBool("Turn", doTurn);
		animator.SetFloat("Direction", targetTurn);

		//animator.speed =  Time.timeSinceLevelLoad * Time.deltaTime;
		//animator.speed = 1 + (animator.speed * 1.5f);
		//print (animator.speed);



	
		

		
		//if (Carl.died == true)
		//{
		//	animator.SetBool("Dead", true);
		//}

		if (Jump == true)

		{
			animator.SetBool("Jump", true);
			Jump = false;
		}
		
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
		{
			if (doTurn) // just triggered
			{								
				targetRotation = transform.rotation * Quaternion.AngleAxis(targetTurn, Vector3.up); // Compute target rotation when doTurn is triggered
				doTurn = false;
			}
			
			
		}
		else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Turn"))
		{
			// calls MatchTarget when in Turn state, subsequent calls are ignored until targetTime (0.9f) is reached .
			animator.MatchTarget(Vector3.one, targetRotation, AvatarTarget.Root, new MatchTargetWeightMask(Vector3.zero, 0.99f), animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0.99f);			
		}
		
	}
}