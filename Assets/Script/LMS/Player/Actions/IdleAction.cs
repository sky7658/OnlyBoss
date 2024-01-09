using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Idle Action", menuName = "Scriptable Objects/Action SO/Idle")]
    public class IdleAction : PlayerAction
    {
        public override void Act(Player controller)
        {
            //controller.SetMoveVector(Vector2.zero);
            //controller.SetAnimation(Vector2.zero);
            controller.SetAnimation("isMove", false);
        }
    }
}

