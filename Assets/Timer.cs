using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public int startTime;
	public float tickSpeed;
	
	float time;

	void Start () 
	{
		time = startTime;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("game");
		}
		if(time > 0)
		{
			time -= Time.deltaTime * tickSpeed;

			if(time <= 0)
			{
				time = 0;
				GameObject.Find("Suitcase").GetComponent<Suitcase>().Close();
				GetComponent<TextMesh>().text = "'R' to restart.";
				GameObject.Find("GameOver").GetComponent<MeshRenderer>().enabled = true;
			}
			else GetComponent<TextMesh>().text = "Time: " + Mathf.Round(time).ToString();
		}
	}
}
