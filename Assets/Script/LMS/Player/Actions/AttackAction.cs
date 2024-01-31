using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Attack Action", menuName = "Scriptable Objects/Action SO/Attack")]
    public class AttackAction : PlayerAction
    {
        public override void Enter(Player controller)
        {
            controller.isAttack = true;
            controller.SetAnimation("Attack");
        }

        public override void Exit(Player controller)
        {
            controller.isAttack = false;
        }
    }
}