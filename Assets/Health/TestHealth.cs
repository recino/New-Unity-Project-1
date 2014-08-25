using UnityEngine;
using System.Collections;

public class TestHealth : MonoBehaviour {
	public YourHealth health;
	public int tempHealth;

	void OnGUI (){
		if (GUI.Button(new Rect (Screen.width / 1.5f,Screen.height/4,100,25),"Regain Health")){
			health.ModifyHealth(1);
		}
		if (GUI.Button(new Rect (Screen.width / 1.5f,Screen.height/4 + Screen.height/10,100,25),"Take Damage")){
			health.ModifyHealth(-1);
		}
		if (GUI.Button(new Rect (Screen.width / 1.5f,Screen.height/4 + Screen.height/10 * 2,100,25),"Add Heart")){
			health.AddHearts(1);
		}
	}
}
