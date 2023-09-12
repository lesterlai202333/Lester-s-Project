using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionThree : StateMachineBehaviour
{

    //OnStateExit is a callback method that Unity calls automatically when an animation state exits, which means I can define custom behavior or actions associated with that transition, like in this case, I defined it so that after the transition ended, the bool is set to false.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AttackController.isAttacking = false; //sets the Isattacking variable in the attackcontroller script to false
     

    }
    //the list of parameters in the brackets provide the information, so that I don't have to declare them and access their data myself
    //public means that this method can be accessed by any other class or scripts
    //void means that it doesn't return a value
    //"override" allows methods of the same name to have different functions(they can be redefined based on a template)
    //animator is a parameter of type Animator, it provides the information of the animator component that's on the GameObject to which the Animator Controller is applied. It allows you to access and change the Animator's properties and states.
    //state info is of type of AnimatorStateInfo, it provides information about the current state of the animator. It includes details like the normalized time of the current state, whether the state is looping, and more.
    //the parameter layer index is an integer that represents the layer index of the Animator state(I only have one layer and its layer index is 0, therefore it's a 0 in the brackets of GetCurrentAnimatorStateInfo().


}
