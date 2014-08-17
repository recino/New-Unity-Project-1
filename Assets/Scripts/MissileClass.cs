using UnityEngine;
using System.Collections;

public class MissileClass : MonoBehaviour {
	
	public int MissilePower = 100;
	public int MissileSpeed = 10000;
	public float SelfDestruct = 1;

	void Start ()
		{
			Destroy (gameObject, SelfDestruct);
		}

	void OnTriggerEnter(Collider otherObject)
	{
		renderer.enabled = false;
	}
}
