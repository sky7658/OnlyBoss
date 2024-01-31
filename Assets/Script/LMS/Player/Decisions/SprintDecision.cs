using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Sprint Decision", menuName = "Scriptable Objects/Decision SO/Sprint")]
    public class SprintDecision : PlayerDecision
    {
        //public override bool Decide(Player controller) => Input.GetKey(KeyCode.LeftShift) && !controller.IsControllerKey("Backs");
        public override bool Decide(Player controller)
        {
            return Input.GetKey(KeyCode.LeftShift) && controller.IsControllerKey("MoveKeys") && !controller.IsControllerKey("Backs") && !controller.isAttack && !controller.isHit;
        }

    }
}