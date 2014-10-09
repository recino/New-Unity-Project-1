using UnityEngine;
using System.Collections;

public class Naration : MonoBehaviour {
	public bool heardNaration = false;
	public AudioClip naration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		if (heardNaration == false){
			audio.PlayOneShot(naration);
			heardNaration = true;
		}
	}
}
