using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

public abstract class MonAction : ScriptableObject
{
    public abstract void Enter(Monster controller);
    public abstract void Act(Monster controller);
    public abstract void Exit(Monster controller);
}