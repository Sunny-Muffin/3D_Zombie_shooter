using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction_anim_rand_behaviour : StateMachineBehaviour
{
    public string m_parameterName = "Reaction_anim_rand";
    public int[] m_stateIDArray = { 0, 1, 2 };

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (m_stateIDArray.Length <= 0)
        {
            animator.SetInteger(m_parameterName, 0);
        }
        else
        {
            int index = Random.Range(0, m_stateIDArray.Length);
            //Debug.Log(m_parameterName + "->" + m_stateIDArray[index]);
            animator.SetInteger(m_parameterName, m_stateIDArray[index]);
        }
    }
}
