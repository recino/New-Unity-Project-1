using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

    public string m_RobotName = "NoName";
    public float m_walkSprint = 2;
    public float m_jumpHeight = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
		if ( Input.GetKey( KeyCode.LeftShift ) )
        {
            m_walkSprint = 4;
        }
        else
        {
            m_walkSprint = 2;
        }
        
        // Move the object forward along its z axis 1 unit/second.
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            transform.Translate( Vector3.right * ( Time.deltaTime * m_walkSprint ) );
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            transform.Translate( Vector3.left * ( Time.deltaTime * m_walkSprint ) );
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            transform.Translate( Vector3.forward * ( Time.deltaTime * m_walkSprint ) );
        }
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            transform.Translate( Vector3.back * ( Time.deltaTime * m_walkSprint ) );
        }
	}
}
