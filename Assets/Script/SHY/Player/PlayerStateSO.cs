using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMS.User;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Objects/State/Player")]
public class PlayerStateSO : ScriptableObject
{
    public PlayerAction[] actions;
    public PlayerTransition[] transitions;

    public void UpdateState(Player controller)
    {
        DoActions(controller);
        checkTransitions(controller);
    }

    private void DoActions(Player controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void checkTransitions(Player controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded) controller.TransitionToState(transitions[i].trueState);
            else controller.TransitionToState(transitions[i].falseState);
        }
    }
}