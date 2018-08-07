using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusTablet : MonoBehaviour {
    
    private TextMesh sizeNr;
    private TextMesh moraleNr;
    private TextMesh foodNr;
    private TextMesh lootNr;
    
    private static int armySize;
    private static int armyMorale;
    private static int food;
    private static int loot;

    private static bool toUpdate;
    
    public static void UpdateStatus (ActiveCards.GameEvent ev)
    {
        armySize = armySize + ev.ArmySize;
        if (armySize > 50)
            armySize = 50;

        armyMorale = armyMorale + ev.ArmyMorale;
        if (armyMorale > 50)
            armyMorale = 50;
        else if (armyMorale < 0)
            armyMorale = 0;

        food += ev.Food - armySize;
        if (food < 0)
            food = 0;

        loot += ev.Loot;
        if (loot < 0)
            loot = 0;

        if (armyMorale == 0)
            armySize--;

        if (food == 0)
            armySize--;
        
        toUpdate = true;
    }

    void Start ()
    {
        armySize = 5;
        armyMorale = 80;
        food = 20;
        loot = 100;

        sizeNr = GameObject.Find("Status Tablet/Men/Nr").GetComponent<TextMesh>();
        moraleNr = GameObject.Find("Status Tablet/Morale/Nr").GetComponent<TextMesh>();
        foodNr = GameObject.Find("Status Tablet/Food/Nr").GetComponent<TextMesh>();
        lootNr = GameObject.Find("Status Tablet/Loot/Nr").GetComponent<TextMesh>();
        
        sizeNr.text = armySize.ToString();
        moraleNr.text = armyMorale.ToString();
        foodNr.text = food.ToString();
        lootNr.text = loot.ToString();
        toUpdate = false;
    }
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            armySize++;
            toUpdate = true; 
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            armySize--;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            armyMorale += 5;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            armyMorale -= 5;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            food += 10;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            food -= 10;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            loot += 100;
            toUpdate = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            loot -= 100;
            toUpdate = true;
        }

        if (toUpdate)
        {




            if (armySize <= 0)
            {
                Scroll.UpdateScrollLost();
            }
            else if (loot >= 1000)
            {
                Scroll.UpdateScrollWin();
            }

            sizeNr.text = armySize.ToString();
            moraleNr.text = armyMorale.ToString();
            foodNr.text = food.ToString();
            lootNr.text = loot.ToString();
            toUpdate = false;
        }
	}
}
