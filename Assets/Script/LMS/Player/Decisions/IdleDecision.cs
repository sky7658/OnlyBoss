using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Idle Decision", menuName = "Scriptable Objects/Decision SO/Idle")]
    public class IdleDecision : PlayerDecision
    {
        public override bool Decide(Player controller) => !Input.anyKey;
    }
}

