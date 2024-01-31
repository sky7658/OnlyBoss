using Script.SHY.Monster;
using UnityEngine;

namespace SHY.Actions
{
    [CreateAssetMenu(fileName = "Attack Action", menuName = "Scriptable Objects/Monster/Action SO/Attack")]
    public class AttackAction : MonAction
    {
        public override void Enter(Monster controller)
        {
            controller.SetAnimation("isMove", false);
            controller.SetAnimation("DoAttack");
            controller.SetAttack();
        }

        public override void Act(Monster controller)
        {
        }

        public override void Exit(Monster controller)
        {
            controller.OffAttack();
        }
    }
}