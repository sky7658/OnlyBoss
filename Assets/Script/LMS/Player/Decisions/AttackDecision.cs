using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Attack Decision", menuName = "Scriptable Objects/Decision SO/Attack")]
    public class AttackDecision : PlayerDecision
    {
        public override bool Decide(Player controller) => Input.GetMouseButtonDown(0) && !controller.isHit;
    }
}
