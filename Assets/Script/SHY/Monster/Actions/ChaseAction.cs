using Script.SHY.Monster;
using UnityEngine;

namespace SHY.Actions
{
    [CreateAssetMenu(fileName = "Chase Action", menuName = "Scriptable Objects/Monster/Action SO/Chase")]
    public class ChaseAction : MonAction
    {
        public override void Enter(Monster controller)
        {
            controller.SetAnimation("isMove", true);
            controller.SetChase();
        }

        public override void Act(Monster controller)
        {
            controller.SetAnimation("MoveType",controller.curSpeed/controller.MaxSpeed);
            controller.LookTarget();
        }

        public override void Exit(Monster controller)
        {
            controller.OffChase();
        }
    }
}