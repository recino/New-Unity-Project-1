using UnityEngine;
using System.Collections;

public class enemy_AI_characterController : MonoBehaviour {

	//Public variables
	public GameObject _Target;
	public float _viewDistance = 10.0f;
	public float _attackDistance = 5.0f;
	public float _Speed = 10.0f;
	public float _RotationDamping = 1.0f;
	public float _Gravity = 20.0f;
	public YourHealth health;
	public float attackCooldown = 2.0f;
	public bool coolDown = false;
	public Controller player;

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

		//_EnemyState = EnemyStateEnum.SeesPlayer;	
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		CheckTargetPosition(_Target);
		//Debug.Log(DetectDistance(_Target));
		//Debug.Log(_EnemyState);
		
		//Finite State Machine
		switch (_EnemyState) 
		{
		case EnemyStateEnum.Idle:
			//Stick Idle stuff here
			break;
		case EnemyStateEnum.SeesPlayer:
			//Stick run here
			RotateToPlayer();
			MoveToPlayer();
			break;
		case EnemyStateEnum.InRange:
			//Stick attack stuff here
			//Debug.Log("blarg");
			if (coolDown == false){ 
				if (player.blocking == false){
					health.ModifyHealth(-1);
					StartCoroutine("AttackTime");
				}
				coolDown = true;
			}
			RotateToPlayer();
			break;
		}
	}

	void MoveToPlayer() {
		Vector3 playerPosition = _Target.transform.position;
		Vector3 direction = (playerPosition - transform.position).normalized;

		//Move enemy to player
		controller.SimpleMove(direction * _Speed * Time.deltaTime);
	}

	void RotateToPlayer() {
		Vector3 playerPosition = _Target.transform.position;
		Vector3 direction = (playerPosition - transform.position).normalized;

		Quaternion rotation = Quaternion.LookRotation(direction);
		rotation = Quaternion.Euler(new Vector3(0f, rotation.eulerAngles.y, 0f));
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _RotationDamping);
	}

	float DetectDistance (GameObject target) {
		return Vector3.Distance(transform.position, target.transform.position);
	}

	void CheckTargetPosition (GameObject target) {

		if (DetectDistance(target) > _viewDistance) {
			_EnemyState = EnemyStateEnum.Idle;
		}
		else if (_viewDistance > DetectDistance(target) && DetectDistance(target) > _attackDistance) {
			_EnemyState = EnemyStateEnum.SeesPlayer;
		}
		else if (_attackDistance > DetectDistance(target)){
			_EnemyState = EnemyStateEnum.InRange;
		}
	}
	IEnumerator AttackTime()
	{
		yield return new WaitForSeconds(attackCooldown);
		coolDown = false;
		//Debug.Log("Again");
	}
}
