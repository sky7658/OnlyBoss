using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "Scriptable Objects/Action SO/Move")]
    public class MoveAction : PlayerAction
    {
        public override void Act(Player controller)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            controller.SetMoveVector(new Vector3(x, 0, z));
            controller.SetAnimation(new Vector2(x, z));
            controller.SetAnimation("isMove", true);
        }
    }
}
