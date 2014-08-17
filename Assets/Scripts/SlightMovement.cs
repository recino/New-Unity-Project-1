using UnityEngine;
using System.Collections;

public class SlightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (Random.Range(-0.000001f, 0.000001f), 0, Random.Range(-0.000001f, 0.000001f));
		 
	}
}
