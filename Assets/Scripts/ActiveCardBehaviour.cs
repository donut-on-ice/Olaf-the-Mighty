using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCardBehaviour : StateMachineBehaviour {

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetBool("ToDiscard", false);
        animator.SetBool("AllSet", false);
    }
}
