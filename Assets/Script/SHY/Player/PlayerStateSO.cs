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

    private void DoEnters(Player controller) { for (int i = 0; i < actions.Length; i++) actions[i].Enter(controller); }
    private void DoActions(Player controller) { for (int i = 0; i < actions.Length; i++) actions[i].Act(controller); }
    private void DoExits(Player controller) { for (int i = 0; i < actions.Length; i++) actions[i].Exit(controller); }

    private void checkTransitions(Player controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                DoExits(controller);
                transitions[i].trueState.DoEnters(controller);
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                if (transitions[i].falseState.transitions.Length != 0) DoExits(controller);
                transitions[i].falseState.DoEnters(controller);
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}