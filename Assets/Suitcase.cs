using UnityEngine;
using System.Collections;

public class Suitcase : MonoBehaviour 
{
	public Sprite closedCase;

	public void Close()
	{
		GetComponent<SpriteRenderer>().sprite = closedCase;
		transform.FindChild("Closed").gameObject.SetActive(true);
	}
}
