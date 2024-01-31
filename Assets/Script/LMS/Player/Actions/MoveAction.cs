using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "Scriptable Objects/Action SO/Move")]
    public class MoveAction : PlayerAction
    {
        public override void Enter(Player controller)
        {
            controller.SetAnimation("isMove", true);
            controller.curSpeed = controller.Data.MaxSpeed * 2 / 3;
        }
        public override void Act(Player controller)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            controller.SetMoveVector(new Vector3(x, 0, z));
            controller.SetAnimation(new Vector2(x, z));

            controller.sprint -= Time.deltaTime;
            if (controller.sprint < 0f) controller.sprint = 0f;

            controller.SetAnimation("Sprint", controller.sprint);
        }
        public override void Exit(Player controller)
        {
            controller.SetMoveVector(new Vector3(0, 0, 0));
            controller.SetAnimation(new Vector2(0, 0));

            controller.SetAnimation("isMove", false);
        }
    }
}
