using UnityEngine;
using System.Collections;

public class enemy_AI_characterController : MonoBehaviour {

	//Public variables
	public GameObject _Target;
	public float _Speed = 10.0f;
	public float _RotationDamping = 1.0f;
	public float _Gravity = 20.0f;

	//Private variables
	enum EnemyStateEnum {
		Idle,
		SeesPlayer,
		InRange
	};

	EnemyStateEnum _EnemyState;

	CharacterController controller;

	// Use this for initialization
	void Start () {

		_EnemyState = EnemyStateEnum.SeesPlayer;	
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
	

		//Finite State Machine
		switch (_EnemyState) 
		{
		case EnemyStateEnum.Idle:
			break;
		case EnemyStateEnum.SeesPlayer:
			RotateToPlayer();
			MoveToPlayer();
			break;
		case EnemyStateEnum.InRange:
			RotateToPlayer();
			break;
		}
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log(other.gameObject == _Target);

		if (other.gameObject == _Target) {
			_EnemyState = EnemyStateEnum.InRange;
		}
	}

//	void OnCollisionEnter(Collision collision) {
//		foreach (ContactPoint contact in collision.contacts) {
//			Debug.DrawRay(contact.point, contact.normal, Color.red);
//		}
//	}

	void MoveToPlayer() {
		Vector3 playerPosition = _Target.transform.position;
//		playerPosition.y = transform.position.y;
		Vector3 direction = (playerPosition - transform.position).normalized;

		//Move enemy to player
//		transform.position = transform.position + direction * _Speed * Time.deltaTime;
		controller.SimpleMove(direction * _Speed * Time.deltaTime);
	}

	void RotateToPlayer() {
		Vector3 playerPosition = _Target.transform.position;
		Vector3 direction = (playerPosition - transform.position).normalized;

		Quaternion rotation = Quaternion.LookRotation(direction);
		rotation = Quaternion.Euler(new Vector3(0f, rotation.eulerAngles.y, 0f));
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _RotationDamping);
	}
}
