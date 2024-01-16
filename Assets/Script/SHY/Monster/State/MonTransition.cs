using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonTransition
{
    public MonDecision decision;
    public MonStateSO trueState;
    public MonStateSO falseState;
}