#pragma strict

var fireButton : GUITexture;

function Update(){

	for (var evt : Touch in Input.touches) {

		var HitTest1 = fireButton.HitTest(evt.position);

		if (evt.phase == TouchPhase.Began) {

			if(HitTest1){

			//do something when button is hit

				Debug.Log ("ButtonGUI Clicked");

				fireButton.enabled = false;
			}
		} 
	} 
}