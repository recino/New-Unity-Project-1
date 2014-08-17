using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GoblinSounds : MonoBehaviour {
	public AudioClip death;
	public bool deathbool = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (deathbool == true){
			audio.PlayOneShot(death);
			deathbool = false;
		}
	}
}
