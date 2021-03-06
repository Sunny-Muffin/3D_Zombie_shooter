using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_anim_rand_behaviour : StateMachineBehaviour
{
    public string m_parameterName = "Idle_anim_rand";
    public int[] m_stateIDArray = { 0, 1 };

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (m_stateIDArray.Length <=0)
        {
            animator.SetInteger(m_parameterName, 0);
        }
        else
        {
            int index = Random.Range(0, m_stateIDArray.Length);
            Debug.Log(m_parameterName + "->" + m_stateIDArray[index]);
            animator.SetInteger(m_parameterName, m_stateIDArray[index]);
        }
    }
}


// OnStateEnter is called before OnStateEnter is called on any state inside this state machine
//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    
//}

// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    
//}

// OnStateExit is called before OnStateExit is called on any state inside this state machine
//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    
//}

// OnStateMove is called before OnStateMove is called on any state inside this state machine
//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    
//}

// OnStateIK is called before OnStateIK is called on any state inside this state machine
//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    
//}

// OnStateMachineEnter is called when entering a state machine via its Entry Node
//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
//{
//    
//}

// OnStateMachineExit is called when exiting a state machine via its Exit Node
//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
//{
//    
//}