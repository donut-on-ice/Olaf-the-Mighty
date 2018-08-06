using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_card1 : MonoBehaviour {

	public static bool clicked1 = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseOver()
	{
		UnityEngine.Debug.Log("hover1");
	}

	private void OnMouseDown()
	{
		clicked1 = true;
		UnityEngine.Debug.Log("click1");
	}
}
