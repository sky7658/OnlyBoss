using Script.SHY.Monster;
using UnityEngine;

namespace SHY.Actions
{
    [CreateAssetMenu(fileName = "Hit Action", menuName = "Scriptable Objects/Monster/Action SO/Hit")]
    public class HitAction : MonAction
    {
        public override void Enter(Monster controller)
        {
            controller.SetAnimation("isMove", false);
            controller.SetAnimation("DoHit");
            controller.SetHit();
        }

        public override void Act(Monster controller)
        {
        }

        public override void Exit(Monster controller)
        {
            controller.OffHit();
        }
    }
}