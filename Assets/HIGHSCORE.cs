using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HIGHSCORE : MonoBehaviour {

	public static int highscore = 0;
  public static int highscore_hard = 0;
	public static int value;
	public bool easyMode = true;
	public bool hardMode;

	Text highscore_text;

	// Use this for initialization
	void Start () {
		highscore_text = GetComponent<Text>();
		highscore = PlayerPrefs.GetInt ("highscore", highscore);;
	  highscore_hard = PlayerPrefs.GetInt ("highscore_hard", highscore_hard);
	}

	// Update is called once per frame
	void Update () {
		if(easyMode)
		{
			if (value > highscore)
			 {
				 highscore_text.color = new Color(224,211,0,255);
				 highscore = value;
				 highscore_text.text = "NEW HIGHSCORE " + highscore;
				 highscore_text.fontSize = 55;
				 PlayerPrefs.SetInt ("highscore", highscore);
			 }
			else if(value < highscore)
			{
				highscore_text.color = Color.white;
				highscore_text.text = "current highscore " + highscore;
			}
		}
		else if (hardMode)
				{
					if (value > highscore_hard)
					 {
						 highscore_text.color = new Color(224,211,0,255);
						 highscore_hard = value;
						 highscore_text.text = "NEW HIGHSCORE hardmode" + highscore_hard;
						 highscore_text.fontSize = 55;
						 PlayerPrefs.SetInt ("highscore_hard", highscore_hard);
					 }
					else if(value < highscore_hard)
					{
						highscore_text.color = Color.white;
						highscore_text.text = "current highscore hardmode " + highscore_hard;
					}
				}
	}
}
