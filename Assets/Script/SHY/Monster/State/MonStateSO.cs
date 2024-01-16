using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Objects/State/Monster")]
public class MonStateSO : ScriptableObject
{
    public MonAction[] actions;
    public MonTransition[] transitions;
    
    public void UpdateState(Monster controller)
    {
        DoActions(controller);
        checkTransitions(controller);
    }
    
    public void EnterState(Monster controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Enter(controller);
        }
    }

    public void ExitState(Monster controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Exit(controller);
        }
    }

    private void DoActions(Monster controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void checkTransitions(Monster controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded) controller.TransitionToState(transitions[i].trueState);
            else controller.TransitionToState(transitions[i].falseState);
        }
    }
}