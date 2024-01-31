using System.Collections;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Idle Action", menuName = "Scriptable Objects/Action SO/Idle")]
    public class IdleAction : PlayerAction
    {
        public override void Enter(Player controller)
        {
            controller.sprint = 0f;
            controller.SetAnimation("isMove", false);
        }
    }
}

