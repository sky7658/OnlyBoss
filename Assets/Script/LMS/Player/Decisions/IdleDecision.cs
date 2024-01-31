using System.Collections;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Idle Decision", menuName = "Scriptable Objects/Decision SO/Idle")]
    public class IdleDecision : PlayerDecision
    {
        public override bool Decide(Player controller) => !controller.IsControllerKey("MoveKeys") && !controller.isAttack && !controller.IsJump && !controller.isHit;
    }
}