using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public bool sheathed = false;
	public float sheathingTime = 1.5f;
	public float attackCooldown = 1.0f;
	public float attackHevyCooldown = 1.5f;
	public float invincablity = 1.5f; 
	public bool blocking = false;
	public bool coolDown = false;
	public bool cantHurt = false;
	public bool takingDamage = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Horizontal") && sheathed == true || Input.GetButton("Vertical") && sheathed == true)
		{
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
			//	Debug.Log ("Hello Rose Tyler.");
				animation.CrossFade("Run_Normal");
			}
			else
			{
				animation.CrossFade("Walk_Normal");
			}
		}

		else if (sheathed == true)
		{
			//animation.CrossFadeQueued("Idol_Normal");
		}

		if (Input.GetButton("Horizontal") && sheathed == false || Input.GetButton("Vertical") && sheathed == false)
		{
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
			//	Debug.Log ("Run for your life!");
				animation.CrossFade("Run_Sword");
			}
			else
			{
				animation.CrossFade("Walk_Sword");
			}
		}

		//else if (sheathed == false)
		//{
			//animation.CrossFadeQueued("Idle_Sword");
			//animation.CrossFadeQueued("Sheathe");
			//StartCoroutine("WaitForSword");
		//}

		if (Input.GetKey(KeyCode.F) && blocking == false)
		{

			animation.CrossFade("Block");
			blocking = true;
		}

		if (Input.GetKey(KeyCode.F) && blocking == true)
		{

			animation.CrossFadeQueued("Block_Hold");
		}

		if (Input.GetKeyUp(KeyCode.F) && blocking == true)
		{
			blocking = false;
		}


		if (!Input.anyKey || !Input.anyKeyDown)
		{
			animation.CrossFadeQueued("Idle_Sword");
		}

		if (Input.GetMouseButtonDown(0) && sheathed == false && coolDown == false){
			animation.Play("Attack 1");
			StartCoroutine("AttackTime");
			coolDown = true;

		}
		else if (Input.GetMouseButtonDown(0) && sheathed == true)
		{
			animation.Play("Unsheathe");
			sheathed = false;
		}

		if (Input.GetMouseButtonDown(1) && sheathed == false && coolDown == false){
			animation.Play("Attack 2");
			StartCoroutine("AttackHeavyTime");
			coolDown = true;
		}
		else if (Input.GetMouseButtonDown(1) && sheathed == true)
		{
			animation.Play("Unsheathe");
			sheathed = false;
		}

		if (takingDamage == true && cantHurt == false)
		{
			animation.Play("Dammaged");
			cantHurt = true;
			StartCoroutine("DamageTakingTime");

		}
	}

	IEnumerator WaitForSword()
	{
		yield return new WaitForSeconds(sheathingTime);
		sheathed = true;
	}

	IEnumerator AttackTime()
	{
		yield return new WaitForSeconds(attackCooldown);
		coolDown = false;
	}

	IEnumerator AttackHeavyTime()
	{
		yield return new WaitForSeconds(attackHevyCooldown);
		coolDown = false;
	}

	IEnumerator DamageTakingTime()
	{
		yield return new WaitForSeconds(invincablity);
		cantHurt = false;
	}
	
}
