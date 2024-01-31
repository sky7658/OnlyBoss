using Script.SHY.Monster;
using UnityEngine;

namespace SHY.Actions
{
    [CreateAssetMenu(fileName = "Wander Action", menuName = "Scriptable Objects/Monster/Action SO/Wander")]
    public class WanderAction : MonAction
    {
        public override void Enter(Monster controller)
        {
            controller.SetAnimation("isMove", true);
            controller.SetWander();
        }

        public override void Act(Monster controller)
        {
            
        }

        public override void Exit(Monster controller)
        {
            controller.OffWander();
        }
    }
}