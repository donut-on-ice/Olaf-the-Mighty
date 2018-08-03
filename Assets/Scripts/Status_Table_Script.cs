using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Table_Script : MonoBehaviour {

    public class GameEvent
    {
        private int armySize;
        private int armyMorale;
        private int food;
        private int loot;

        GameEvent() {
            armySize = 0;
            armyMorale = 0;
            food = 0;
            loot = 0;
        }

        GameEvent(int ars, int arm, int f, int l)
        {
            armySize = ars;
            armyMorale = arm;
            food = f;
            loot = l;
        }

        public int getArmySize() {
            return armySize;
        }

        public int getArmyMorale()
        {
            return armyMorale;
        }

        public int getFood()
        {
            return food;
        }

        public int getLoot()
        {
            return loot;
        }

        public void setArmySize(int nr)
        {
            armySize = nr;
        }

        public void setArmyMorale(int nr)
        {
            armyMorale = nr;
        }

        public void setFood(int nr)
        {
            food = nr;
        }

        public void setLoot(int nr)
        {
            loot = nr;
        }
    }

    private static int armySize = 0;
    private static int armyMorale = 0;
    private static int food = 0;
    private static int loot = 0;

    public static void UpdateStatus(GameEvent ev)
    {
        armySize = ev.getArmySize();
        armyMorale = ev.getArmyMorale();
        food = ev.getFood();
        loot = ev.getLoot();
    }

    // Use this for initialization
    void Start () {
        armySize = 0;
        armyMorale = 0;
        food = 0;
        loot = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
