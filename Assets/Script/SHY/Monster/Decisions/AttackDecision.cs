using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Decision", menuName = "Scriptable Objects/Monster/Decision SO/Attack")]
public class AttackDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return AttackCheck(controller);
    }

    private bool AttackCheck(Monster controller)
    {
        return controller.GetDisFromtarget();
    }
}