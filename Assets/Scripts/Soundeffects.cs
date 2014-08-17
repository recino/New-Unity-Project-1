using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Soundeffects : MonoBehaviour {
	public AudioClip strike;
	public AudioClip blood;
	public AudioClip heavy;

	public bool strikebool = false;
	public bool bloodbool = false;
	public bool heavybool = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (strikebool == true){
			Debug.Log ("Shing!");
			audio.PlayOneShot(strike);
			strikebool = false;
		}

		if (bloodbool == true){
			Debug.Log ("Squelch!");
			audio.PlayOneShot(blood);
			bloodbool = false;
		}

		if (heavybool == true){
			Debug.Log ("Slam!");
			audio.PlayOneShot(heavy);
			heavybool = false;
		}

	}
}

