using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

[CreateAssetMenu(fileName = "Hit Decision", menuName = "Scriptable Objects/Monster/Decision SO/Hit")]
public class HitDecision : MonDecision
{
    public override bool Decide(Monster controller)
    {
        return HitCheck(controller);
    }

    private bool HitCheck(Monster controller)
    {
        return controller.IsHit;
    }
}