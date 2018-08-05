using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusTablet : MonoBehaviour {
    
    private TextMesh sizeNr;
    private TextMesh moraleNr;
    private TextMesh foodNr;
    private TextMesh lootNr;
    
    private int armySize;
    private int armyMorale;
    private int food;
    private int loot;

    private bool toUpdate;

    public void UpdateStatus (ActiveCards.GameEvent ev)
    {
        armySize = armySize + ev.ArmySize;
        if (armySize > 50)
            armySize = 50;
        else if (armySize < 0)
            armySize = 0;

        armyMorale = armyMorale + ev.ArmyMorale;
        if (armyMorale > 50)
            armyMorale = 50;
        else if (armyMorale < 0)
            armyMorale = 0;

        food += ev.Food;

        loot += ev.Loot;

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
        if (toUpdate)
        {
            sizeNr.text = armySize.ToString();
            moraleNr.text = armyMorale.ToString();
            foodNr.text = food.ToString();
            lootNr.text = loot.ToString();
            toUpdate = false;
        }
	}
}
