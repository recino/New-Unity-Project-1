using UnityEngine;
using System.Collections;

public class RestHouse : MonoBehaviour {
	public YourHealth health;
	public bool CoolDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay()
	{
		if (CoolDown == false){
			health.ModifyHealth(1);
			CoolDown = true;
			StartCoroutine("SlowRecovery");
		}
	}

	IEnumerator SlowRecovery(){
		yield return new WaitForSeconds(3);
		CoolDown = false;
	}
}
