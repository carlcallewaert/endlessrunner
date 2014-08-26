#pragma strict

function Start () {

}

var breakrecord : boolean = false;

function Update () {

if ((breakrecord == false) && (Move_Rotate01.thescore > 4))

	{
Everyplay.StartRecording();
breakrecord = true;

	}

}