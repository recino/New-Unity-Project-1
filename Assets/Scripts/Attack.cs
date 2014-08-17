using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("fire1")){


	}
	void OnTriggerStay(Collider other){
	//void OnCollisionEnter(Collision other){
		//Debug.Log ("hi");
		if (other.gameObject.tag == "Enemy"){
			Debug.Log ("yo");
			if (Input.GetKeyDown(KeyCode.F)){
				Debug.Log ("hi");
			}
		}
	}
}
