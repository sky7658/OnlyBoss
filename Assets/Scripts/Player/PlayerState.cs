using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "ScriptableObjects/State/Player")]
public class PlayerStateSO : ScriptableObject
{
    public PlayerAction[] actions;
    public PlayerTransition[] transitions;

    public void UpdateState(PlayerController controller)
    {
        DoActions(controller);
        checkTransitions(controller);
    }

    private void DoActions(PlayerController controller)
    {
        for(int i = 0; i < actions.Length; i++){
            actions[i].Act(controller);
        }
    }

    private void checkTransitions(PlayerController controller)
    {
        for(int i = 0; i < transitions.Length; i++){
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if(decisionSucceeded) controller.TransitionToState(transitions[i].trueState);
            else controller.TransitionToState(transitions[i].falseState);
        }
    }
}
