using System.Collections;
using System.Collections.Generic;
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
            if ((x != 0 || z != 0) && Input.anyKey) return true;
            return false;
        }
    }
}
