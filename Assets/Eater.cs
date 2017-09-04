using UnityEngine;
using System.Collections;

public class Eater : MonoBehaviour 
{
	int itemsLeft;
	TextMesh tm;

	void UpdateScore()
	{
		tm.text = "Items Left: " + itemsLeft.ToString();
	}

	void Start()
	{
		itemsLeft = GameObject.FindGameObjectsWithTag("Item").Length;
		tm = GameObject.Find("Score").GetComponent<TextMesh>();

		UpdateScore();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Destroy(other.gameObject);
		--itemsLeft;
		UpdateScore();

		if(itemsLeft == 0)
		{
			GameObject.Find("Suitcase").GetComponent<Suitcase>().Close();
			GameObject.Find("Win").GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
