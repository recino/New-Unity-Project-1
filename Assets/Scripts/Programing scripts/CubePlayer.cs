using UnityEngine;
using System.Collections;

public class CubePlayer : MonoBehaviour {

	public string m_name = "";
	public float m_RotationSpeedPerFrame = 60;

	ControllManager m_ControllManager;
	bool m_IsInControl = false;

	void Awake(){
		GameObject managerObject = GameObject.Find("ControllManager");
		if (managerObject == null){
			Debug.Log ("Nope");
			return;
		}

		m_ControllManager = managerObject.GetComponent<ControllManager>();
		if(m_ControllManager == null){
			Debug.Log ("Haha");
			return;
		}
		m_ControllManager.RegisterCharacter(this);
		Debug.Log ("Got it!");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && m_IsInControl){
			transform.Rotate(0,m_RotationSpeedPerFrame * Time.deltaTime,0, Space.World);
		}
	}

	public void GiveControl(){
		m_IsInControl = true;
		renderer.material.color = Color.blue;
	}

	public void TakeControl(){
		m_IsInControl = false;
		renderer.material.color = Color.white;
	}

	/*public void SetIsInControl(bool newVal){
		m_IsInControl = newVal;
		Color newColor = Color.white;
		if(newVal == true){
			newColor = Color.red;
		}
	}*/

}
