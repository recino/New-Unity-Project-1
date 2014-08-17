using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	public string CubeName = "Alfred";
	public float RotationSpeedPerFrame = 1.0f;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0,0,0);
		Debug.Log(CubeName);

		MyClass myClass = new MyClass();
		myClass.a = 6;

		int myInt = 5;
		ChangeValue(myInt);

		Debug.Log(myInt);

		ChangeValue(myClass);
		Debug.Log(myClass.a);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			transform.Rotate(0,RotationSpeedPerFrame * Time.deltaTime,0, Space.World);
		}
	}

	void ChangeValue (int valToChange){
		valToChange = 3000;
		Debug.Log (valToChange);
	}

	void ChangeValue (MyClass referencedMyClass ){
		referencedMyClass.a = 9001;
		Debug.Log (referencedMyClass.a);
	}
}


public class MyClass{
	public int a, b, c, d, e, f;

}