using System;
using System.Collections;
using System.Collections.Generic;
using Script.SHY.General;
using Script.SHY.Monster;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Monster monster;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //IDamageable 인터페이스를 상속받은 오브젝트만 데미지를 입음
        IDamgeable damageableComponent = other.GetComponent<IDamgeable>();

        if (damageableComponent != null)
        {
            damageableComponent.TakeHit(monster.curAtk, this.transform);
        }
    }
}
