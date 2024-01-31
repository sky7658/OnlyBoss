using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private EntitySO data;
    public EntitySO Data { get; private set; }
    
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
        Data = data;

        curHP = data.MaxHp;
        curSpeed = data.MaxSpeed * 2 / 3;
        defense = data.MaxDef;
    }

    protected abstract void Dead();
}
