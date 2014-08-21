using UnityEngine;
using System.Collections;

public class enemy_AI : MonoBehaviour {

	//Public variables
	public GameObject _Target;
	public float _Speed = 10.0f;

	//Private variables
	enum EnemyStateEnum {
		Idle,
		SeesPlayer,
		InRange
	};

//	EnemyStateEnum _EnemyState = EnemyStateEnum.SeesPlayer;
	EnemyStateEnum _EnemyState;

	// Use this for initialization
	void Start () {

		_EnemyState = EnemyStateEnum.SeesPlayer;	
	
	}
	
	// Update is called once per frame
	void Update () {
	

		//Finite State Machine
		switch (_EnemyState) 
		{
		case EnemyStateEnum.Idle:
			break;
		case EnemyStateEnum.SeesPlayer:
//			Debug.Log("Sees the Player");
			MoveToPlayer();
			break;
		}
	}

	void MoveToPlayer() {
		Vector3 playerPosition = _Target.transform.position;
		Vector3 direction = (playerPosition - transform.position).normalized;

		Debug.Log(playerPosition);
		Debug.DrawRay(transform.position, direction);

		//Move enemy to player
//		rigidbody.MovePosition(transform.position + direction * _Speed * Time.deltaTime);
		transform.position = transform.position + direction * _Speed * Time.deltaTime;
	}
}
