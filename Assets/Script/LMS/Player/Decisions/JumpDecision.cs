using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Jump Decision", menuName = "Scriptable Objects/Decision SO/Jump")]
    public class JumpDecision : PlayerDecision
    {
        public override bool Decide(Player controller)
        {
            if(Input.GetKey(KeyCode.Space) && !controller.IsJump)
            {
                controller.IsJump = true;
                controller.SetAnimation("Jump");
                controller.SetMoveVector(new Vector3(0, 3, 0));

                return true;
            }
            return false;
        }
    }
}