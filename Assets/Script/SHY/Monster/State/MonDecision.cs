using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

public abstract class MonDecision : ScriptableObject
{
    public abstract bool Decide(Monster controller);
}