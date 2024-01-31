using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    [CreateAssetMenu(fileName = "Hit Action", menuName = "Scriptable Objects/Action SO/Hit")]
    public class HitAction : PlayerAction
    {
        public override void Enter(Player controller)
        {
            controller.SetAnimation("Hit");
        }
        public override void Act(Player controller)
        {
        }
        public override void Exit(Player controller)
        {
        }
    }
}
