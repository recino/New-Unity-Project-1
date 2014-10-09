using UnityEngine;
using System.Collections;

public class AttackRecieve : MonoBehaviour {
	public int hits = 0;
	public int check = 0;
	public int hitsLeft = 4;
	public GoblinSounds[] sounds;
	public AudioClip hurt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (check < hits){
			check = hits;
			audio.PlayOneShot(hurt);
		}

		if (hits >= hitsLeft){
			foreach (GoblinSounds sound in sounds){
				sound.deathbool = true;
			}
			Destroy(gameObject);
	
		}
	}
}
