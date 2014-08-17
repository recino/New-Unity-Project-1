using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllManager : MonoBehaviour {

	LinkedList<CubePlayer>  m_Players = new LinkedList<CubePlayer>();
	LinkedListNode<CubePlayer> m_CurrentPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			GiveControlToNextPlayer();
		}
	}

	public void RegisterCharacter(CubePlayer player){

		m_Players.AddLast(player);

		if (m_Players.Count == 1){
			GiveControlToNextPlayer();
		}
	}

	private void GiveControlToNextPlayer(){

			if (m_CurrentPlayer != null){
				m_CurrentPlayer.Value.TakeControl();
				
			}
			
			if (m_CurrentPlayer == null || m_CurrentPlayer.Next == null){
				m_CurrentPlayer = m_Players.First;
			}
			
			else{
				m_CurrentPlayer = m_CurrentPlayer.Next;
			}
			
			if(m_CurrentPlayer != null){
				m_CurrentPlayer.Value.GiveControl();
			}

	}
}
