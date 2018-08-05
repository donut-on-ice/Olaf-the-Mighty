using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    
    private TextMesh titleText;
    private TextMesh descriptionText;

    private string title;
    private string description;

    private bool toUpdate;

    public void UpdateScroll (ActiveCards.GameEvent ev)
    {
        title = ev.Title;
        description = ev.Description;
        toUpdate = true;
    }

    public void ClearScroll (ActiveCards.GameEvent ev)
    {
        title = "";
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
