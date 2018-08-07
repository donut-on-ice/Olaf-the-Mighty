using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour {

    public int id;
    private ActiveCards.GameEvent myEvent;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void OnMouseEnter()
    {
        if (id == 1)
        {
            myEvent = ActiveCards.eventLeft;
        }
        else if (id == 2)
        {
            myEvent = ActiveCards.eventMiddle;
        }
        else if (id == 3)
        {
            myEvent = ActiveCards.eventRight;
        }

        Scroll.UpdateScroll(myEvent);
    }

    private void OnMouseExit()
    {
        Scroll.ClearScroll();
    }

    private void OnMouseDown()
    {
        if (id == 1)
        {
            myEvent = ActiveCards.eventLeft;
        }
        else if (id == 2)
        {
            myEvent = ActiveCards.eventMiddle;
        }
        else if (id == 3)
        {
            myEvent = ActiveCards.eventRight;
        }

        LogTablet.AddEntry(myEvent);
        StatusTablet.UpdateStatus(myEvent);

        //ActiveCards.cardLeft.GetComponent<Animator>().SetBool("ToDiscard", true);
        //ActiveCards.cardMiddle.GetComponent<Animator>().SetBool("ToDiscard", true);
        //ActiveCards.eventRight.GetComponent<Animator>().SetBool("ToDiscard", true);
    }
}
