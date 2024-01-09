using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private EntitySO data;
    
    public float curSpeed;
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

    protected virtual void Initailized()
    {
        curHP = data.MaxHp;
        curSpeed = data.MaxSpeed / 2;
        defense = data.MaxDef;
    }

    protected abstract void Dead();
}
