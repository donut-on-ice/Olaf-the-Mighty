using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTablet : MonoBehaviour {
    
    private TextMesh logText;

    private static string logEntry;

    private static bool toUpdate;

    public static void AddEntry (ActiveCards.GameEvent ev)
    {
        logEntry = ev.LogEntry;
        toUpdate = true;
    }

    void Start ()
    {
        logEntry = "";

        logText = GameObject.Find("Log Tablet/Log Text").GetComponent<TextMesh>();

        logText.text = logEntry;
        toUpdate = false;
    }
	
	void Update ()
    {
        if (toUpdate)
        {
            logText.text = logEntry + "\n\n" + logText.text;
            toUpdate = false;
        }
	}
}
