using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Sprint Action", menuName = "Scriptable Objects/Action SO/Sprint")]
    public class SprintAction : PlayerAction
    {
        public override void Enter(Player controller)
        {
            controller.SetAnimation("isMove", true);
            controller.curSpeed = controller.Data.MaxSpeed;
        }
        public override void Act(Player controller)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            controller.SetMoveVector(new Vector3(x, 0, z));
            controller.SetAnimation(new Vector2(x, z));

            controller.sprint += Time.deltaTime;
            if (controller.sprint > 1f) controller.sprint = 1f;

            controller.SetAnimation("Sprint", controller.sprint);
        }
        public override void Exit(Player controller)
        {
            controller.SetAnimation("isMove", false);
        }
    }
}
