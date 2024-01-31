using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMS.User;

public class PlayerAction : ScriptableObject
{
    public virtual void Enter(Player controller) { }
    public virtual void Act(Player controller) { }
    public virtual void Exit(Player controller) { }
}
