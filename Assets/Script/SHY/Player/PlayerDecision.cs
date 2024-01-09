using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMS.User;

public abstract class PlayerDecision : ScriptableObject
{
    public abstract bool Decide(Player controller);
}
