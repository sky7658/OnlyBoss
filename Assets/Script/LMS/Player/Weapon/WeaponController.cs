using LMS.User;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    public class WeaponController : MonoBehaviour
    {
        private float originAtk;
        private float maxAtk;

        private Collider wCollider;
        public void SetCollider(bool value) => wCollider.enabled = value;

        private void Awake()
        {
            wCollider = GetComponent<Collider>();
        }

        public void Initialized(float originAtk, float maxAtk)
        {
            this.originAtk = originAtk;
            this.maxAtk = maxAtk;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Monster") return;

            //if (other.TryGetComponent<IDamageable>(out var _obj))
            //{
            //    SetCollider(false);
            //}
        }
    }
}
