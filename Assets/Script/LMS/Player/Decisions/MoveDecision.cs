using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Move Decision", menuName = "Scriptable Objects/Decision SO/Move")]
    public class MoveDecision : PlayerDecision
    {
        public override bool Decide(Player controller)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            return (x != 0 || z != 0) && controller.IsControllerKey("MoveKeys") && !controller.isAttack && (!Input.GetKey(KeyCode.LeftShift) || controller.IsControllerKey("Backs")) && !controller.IsLand && !controller.isHit;
        }
    }
}