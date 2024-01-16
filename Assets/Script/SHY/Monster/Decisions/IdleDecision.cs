using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle Decision", menuName = "Scriptable Objects/Monster/Decision SO/Idle")]
public class IdleDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return IdleCheck(controller);
    }

    private bool IdleCheck(Monster controller)
    {
        return controller.IsAutoChange;
    }
}