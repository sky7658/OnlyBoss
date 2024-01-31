using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Hit Decision", menuName = "Scriptable Objects/Decision SO/Hit")]
    public class HitDecision : PlayerDecision
    {
        //public override bool Decide(Player controller) => Input.GetKey(KeyCode.LeftShift) && !controller.IsControllerKey("Backs");
        public override bool Decide(Player controller) => controller.isHit;
    }
}