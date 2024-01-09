using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMS.User;

public abstract class PlayerAction : ScriptableObject
{
    public abstract void Act(Player controller);
}
