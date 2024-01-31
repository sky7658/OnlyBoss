using UnityEngine;

namespace Script.SHY.General
{
    public interface IDamgeable
    {
        void TakeHit(float damage, Transform pos);
    }
}