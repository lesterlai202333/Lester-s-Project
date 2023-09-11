using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScript : StateMachineBehaviour //this script belongs to the StateMachineBehaviour class.
{


  
    
    //public means that this method can be accessed by any other class or scripts
    //void means that it doesn't return a value
    //"override" allows methods of the same name to have different functions(they can be redefined based on a template)

    //OnStateUpdate is a callback method in Unity that gets called during each frame while the animation state is active.
    //inside the brackets are a list of parameters defined by unity, so 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//the list of parameters provide the information, so that I don't have to declare them and access their data myself
    {
        if (AttackController.isAttacking)
        {
            AttackController.instance.anim.Play("Attack 1"); //if the bool is true, the first attack animation is played
      
   
        }
    }
    //animator is a parameter of type Animator, it provides the information of the animator component that's on the GameObject to which the Animator Controller is applied. It allows you to access and change the Animator's properties and states.
    //state info is of type of AnimatorStateInfo, it provides information about the current state of the animator. It includes details like the normalized time of the current state, whether the state is looping, and more.
    //the parameter layer index is an integer that represents the layer index of the Animator state(I only have one layer and its layer index is 0, therefore it's a 0 in the brackets of GetCurrentAnimatorStateInfo().
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //OnStateExit is a callback method that Unity calls automatically when an animation state exits, which means I can define custom behavior or actions associated with that transition, like in this case, I defined it so that after the transition ended, the bool is set to false.

        AttackController.isAttacking = false; //sets the Isattacking variable in the attackcontroller script to false
    


    }

   
}

// && !AttackController.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("HeroKnight_Jump")