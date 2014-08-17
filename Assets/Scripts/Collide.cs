using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public bool pillsHere = false;
	public AttackRecieve recieve;
	public Soundeffects[] sounds;
	public Soundeffects[] sounds2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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

			if (pillsHere == false){
				pillsHere = true;
				//Debug.Log("So true");
			}
			if (pillsHere == true){
				if (Input.GetMouseButtonDown(0)){
					recieve.hits = recieve.hits + 1;
					foreach (Soundeffects sound2 in sounds2){
						sound2.bloodbool = true;
					}
				//	Debug.Log("you know it");
				}
				
				if (Input.GetMouseButtonDown(1)){
					recieve.hits = recieve.hits + 2;
					foreach (Soundeffects sound2 in sounds2){
						sound2.bloodbool = true;
					}
				//	Debug.Log("You do know it, right?");
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (pillsHere == true){
			pillsHere = false;
		}

	}
}
