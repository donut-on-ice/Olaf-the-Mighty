using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    
    private TextMesh titleText;
    private TextMesh descriptionText;

    private static string title;
    private static string description;

    private static bool toUpdate;
    
    public static void UpdateScroll (ActiveCards.GameEvent ev)
    {
        title = ev.Title;
        description = ev.Description;
        toUpdate = true;
    }

    public static void ClearScroll ()
    {
        title = "";
        description = "";
        toUpdate = true;
    }

    public static void UpdateScrollLost(){
        title = "You lost";
        description = "";
        toUpdate = true;
    }

    public static void UpdateScrollWin()
    {
        title = "You won";
        description = "";
        toUpdate = true;
    }

    void Start ()
    {
        title = "";
        description = "";

        titleText = GameObject.Find("Scroll/Title").GetComponent<TextMesh>();
        descriptionText = GameObject.Find("Scroll/Description").GetComponent<TextMesh>();

        titleText.text = title;
        descriptionText.text = description;
        toUpdate = false;
    }
	
	void Update ()
    {
        if (toUpdate)
        {
            titleText.text = title;
            descriptionText.text = description;
            toUpdate = false;
        }
	}
}
