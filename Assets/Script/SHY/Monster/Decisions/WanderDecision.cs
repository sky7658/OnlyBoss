using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

[CreateAssetMenu(fileName = "Wander Decision", menuName = "Scriptable Objects/Monster/Decision SO/Move")]
public class WanderDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return WanderCheck(controller);
    }

    private bool WanderCheck(Monster controller)
    {
        return controller.IsAutoChange;
    }
}
