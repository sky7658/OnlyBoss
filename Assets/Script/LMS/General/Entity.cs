using System.Collections;
using System.Collections.Generic;
using Script.SHY.General;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamgeable
{
    [SerializeField] private EntitySO data;
    public EntitySO Data { get; private set; }
    
    public float curSpeed;
    public float MaxSpeed
    {
        get { return data.MaxSpeed; }
    }
    public float defense;
    private float curHP;
    public float CurHP
    {
        get { return curHP; }
        set
        {
            curHP = Mathf.Clamp(value, 0, data.MaxHp);

            if (curHP <= 0)
            {
                Dead();
                return;
            }
        }
    }
    public float curAtk;

    private void Start()
    {
        Initailized();
    }
    
    public virtual void TakeHit(float damage, Transform pos)
    {
        if (curHP <= 0) return;
        CurHP -= damage;
    }

    protected virtual void Initailized()
    {
        Data = data;

        curHP = data.MaxHp;
        curSpeed = data.MaxSpeed * 2 / 3;
        defense = data.MaxDef;
    }

    protected abstract void Dead();
}
