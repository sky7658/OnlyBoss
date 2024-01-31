using Script.SHY.Monster;
using UnityEngine;

namespace SHY.Actions
{
    [CreateAssetMenu(fileName = "Idle Action", menuName = "Scriptable Objects/Monster/Action SO/Idle")]
    public class IdleAction : MonAction
    {
        public override void Enter(Monster controller)
        {
            controller.SetAnimation("isMove", false);
            controller.SetAutoTime();
        }

        public override void Act(Monster controller)
        {
        }

        public override void Exit(Monster controller)
        {
            controller.OffAutoTime();
        }
    }
}