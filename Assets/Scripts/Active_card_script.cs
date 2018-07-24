using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script : MonoBehaviour {

    private Animator animator;
    private int state = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = 0;
        animator.Play("Card_1_idle_deck");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            switch (state) {
                case 0:
                    state++;
                    animator.Play("Card_1_draw");
                    animator.
                    break;
                case 1:
                    state++;
                    animator.Play("Card_1_idle_table");
                    animator.StopPlayback();
                    break;
                case 2:
                    state++;
                    animator.Play("Card_1_discard");
                    animator.StopPlayback();
                    break;
                case 3:
                    state = 0;
                    animator.Play("Card_1_idle_deck");
                    animator.StopPlayback();
                    break;
            }
        }
    }
}
