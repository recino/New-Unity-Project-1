using UnityEngine;
using System.Collections;

public class NewLEvel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		Application.LoadLevel("Might as Well");
	}
}
