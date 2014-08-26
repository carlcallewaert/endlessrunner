

var masterobject : GameObject;
var boxstraight2 : GameObject; 
private var thePosition = Vector3 (0,0,0);
static var thescore : int = 0f;
var scoretext : GUIText;
var highscoretext : GUIText;
static var highscore : int = 0f;
//var anim : Animator; 
var childAnimtor : Animator;
var theotherbridge : GameObject;
//load highscore


function Start (){



//now the hight score in the start function
highscore = PlayerPrefs.GetInt("highscore");
if (highscore > 0f) {		
	highscoretext.text = "Highscore:" + highscore;
}
else 
{
highscoretext.text = "" + 0f;
}
}

function Resethighscore()
{
highscore = 0f;
PlayerPrefs.SetInt("highscore", 0f);
}


function OnTriggerEnter (other : Collider) {
			
var whichdirection: int = Random.Range(1, 4);
//randomly activate the bridge or not..
var bridgeactiveornot: int = Random.Range(1,4);
if (bridgeactiveornot == 1){
theotherbridge.gameObject.active = true;
	}
else 
{
theotherbridge.gameObject.active = false;
}

		
		//forward
		if (whichdirection == 1)
		{
		masterobject.transform.position = masterobject.transform.TransformPoint(0, 0, 16);
		boxstraight2.transform.position = masterobject.transform.position;	
		boxstraight2.transform.rotation = masterobject.transform.rotation;
		//play animation straight
			if(!childAnimtor.GetCurrentAnimatorStateInfo(0).IsName("forward"))
			childAnimtor.SetTrigger("forward");
			
		thescore++;	
		}	
		
		//left			
		if (whichdirection == 2)
			{
			masterobject.transform.position = masterobject.transform.TransformPoint(4, 0, 16);	
			masterobject.transform.localEulerAngles.y = masterobject.transform.localEulerAngles.y - 90;
			boxstraight2.transform.position = masterobject.transform.position;
			boxstraight2.transform.rotation = masterobject.transform.rotation;
			thescore++;	
			//play animation left
			//anim.SetTrigger;
			if(!childAnimtor.GetCurrentAnimatorStateInfo(0).IsName("left"))
		    childAnimtor.SetTrigger("left");
			
			}	
		
		//right
		if (whichdirection == 3)
			{
			masterobject.transform.position = masterobject.transform.TransformPoint(0, 0, 20);	
			masterobject.transform.localEulerAngles.y = masterobject.transform.localEulerAngles.y + 90;
			boxstraight2.transform.position = masterobject.transform.position;
			boxstraight2.transform.rotation = masterobject.transform.rotation;	
			thescore++;	
			//play animation right
			//anim.SetTrigger("right");
			if(!childAnimtor.GetCurrentAnimatorStateInfo(0).IsName("right"))
			childAnimtor.SetTrigger("right");
			}
			
					
		// points and highscore	
		scoretext.text = "Blocks:" + thescore + "";
		
		if (highscore < thescore )
		
		{
		highscore = thescore;
		highscoretext.text = "Highscore:" + highscore;
		PlayerPrefs.SetInt("highscore", highscore);
		}

				
	
	
}


