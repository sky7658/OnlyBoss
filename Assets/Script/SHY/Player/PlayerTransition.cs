using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerTransition
{
    public PlayerDecision decision;
    public PlayerStateSO trueState;
    public PlayerStateSO falseState;
}
