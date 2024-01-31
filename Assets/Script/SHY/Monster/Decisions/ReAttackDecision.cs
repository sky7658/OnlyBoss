using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

[CreateAssetMenu(fileName = "ReAttack Decision", menuName = "Scriptable Objects/Monster/Decision SO/ReAttack")]
public class ReAttackDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return AttackCheck(controller);
    }

    private bool AttackCheck(Monster controller)
    {
        return controller.GetDisFromtarget()&&!controller.IsAttack;
    }
}