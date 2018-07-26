using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script : MonoBehaviour
{

    private Animator animator;
    //private Animation anim;
    private int state = 0;
    public bool paused;

    void Start()
    {
        animator = GetComponent<Animator>();
        //anim = GetComponent<Animation>();
        animator.Play("Card_1_idle_deck");
        //anim.Play("Card_1_idle_deck");

        state = 0;
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_1_draw"))
                {
                    if(paused) Pause();
                    animator.Play("Card_1_draw");
                }
		        ++state;
                break;

            case 1:
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_1_draw"))
                {
                    animator.Play("Card_1_idle_table");
                    if (!paused) Pause();
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //Pause();		// unpauses
                        ++state;
                    }
                }
                break;

            case 2:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_1_discard"))
				{
					if(paused) Pause();
					animator.Play("Card_1_discard");
				}
				++state;
				break;

            case 3:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_1_discard"))
				{
					animator.Play("Card_1_idle_deck");
					if (!paused) Pause();
					if (Input.GetKeyDown(KeyCode.Space))
					{
						//Pause();		// unpauses
						state = 0;
					}
				}
				break;
        }
    }
    

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }

}
