using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public bool pillsHere = false;
	public AttackRecieve recieve;
	public Controller controlls;
	public Soundeffects[] sounds;
	public Soundeffects[] sounds2;
	public float AttackDistance = 2.0f;
	public bool coolDown = false;
	public float attackCooldown = 1.0f;
	public float attackHevyCooldown = 1.5f;

	GameObject[] Goblins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		Goblins = GameObject.FindGameObjectsWithTag("Enemy");
//		Debug.Log(Goblins);

		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			foreach (Soundeffects sound in sounds){
				sound.strikebool = true;
			}
		if (Input.GetMouseButtonDown(1)){
			foreach (Soundeffects sound2 in sounds2){
				sound2.heavybool = true;
			}
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Enemy"){
			recieve = other.GetComponent<AttackRecieve>();

		//	Debug.Log("Ping-ping!");
			if (pillsHere == false){
				pillsHere = true;
				//Debug.Log("So true");
			}
			if (pillsHere == true){
				if (Input.GetMouseButtonDown(0) && coolDown == false){
					recieve.hits = recieve.hits + 1;
					StartCoroutine("AttackTime");
					coolDown = true;
					foreach (Soundeffects sound2 in sounds2){
						sound2.bloodbool = true;
					}
				//	Debug.Log("you know it");
				}
				
				if (Input.GetMouseButtonDown(1) && coolDown == false){
					recieve.hits = recieve.hits + 2;
					StartCoroutine("AttackHeavyTime");
					coolDown = true;
					foreach (Soundeffects sound2 in sounds2){
						sound2.bloodbool = true;
					}
				//	Debug.Log("You do know it, right?");
				}
			}
		}
	}

	IEnumerator AttackTime()
	{
		yield return new WaitForSeconds(attackCooldown);
		coolDown = false;
		Debug.Log("Again");
	}
	
	IEnumerator AttackHeavyTime()
	{
		yield return new WaitForSeconds(attackHevyCooldown);
		coolDown = false;
	}

	
	void OnTriggerExit(Collider other){
		if (pillsHere == true){
			pillsHere = false;
		}

	}
}
