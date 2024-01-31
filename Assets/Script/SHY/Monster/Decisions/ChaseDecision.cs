using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase Decision", menuName = "Scriptable Objects/Monster/Decision SO/Chase")]
public class ChaseDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return ChaseCheck(controller);
    }

    private bool ChaseCheck(Monster controller)
    {
        return controller.GetChaseDis();
    }
}