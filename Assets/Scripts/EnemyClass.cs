using UnityEngine;
using System.Collections;

public class EnemyClass : MonoBehaviour
{
	
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength;
	
	//Here is the problem
	//I do not want otherGameObject to be assigned in Inspector
	//I want it to be any object with the tag "Missile" which collides with Enemy
	public GameObject otherGameObject;
	private MissileClass missileClass;

	void Start ()
	{
		healthBarLength = Screen.width / 2;
	}
	
	void Awake ()
		{
			missileClass = otherGameObject.GetComponent <MissileClass>();
		}
	
	void OnTriggerEnter(Collider otherObject)
		{		
			if (otherObject.tag == "Missile")
				{	
					curHealth -= missileClass.MissilePower;
					if(curHealth <= 0)
						{
							Destroy (gameObject);
						}
				}
    	}
	
	void OnGUI ()
		{
			GUI.contentColor = Color.green;
			GUI.Box (new Rect(20, 80, healthBarLength, 40), curHealth + "/" + maxHealth);
		
			if(curHealth < 0)
				curHealth = 0;
	
			if(curHealth >100)
				curHealth = 100;
	
			if(maxHealth <1)
				maxHealth = 1;
	
		healthBarLength = (Screen.width / 2) * (curHealth / (float) maxHealth);
		}
	
}
