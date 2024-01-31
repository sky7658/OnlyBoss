using System.Collections;
using System.Collections.Generic;
using Script.SHY.Monster;
using UnityEngine;

public class Killer : Monster
{
    [SerializeField] private Collider[] handCollider = new Collider[2];
    [SerializeField] private int _attackType = 2;
    protected override void Awake()
    {
        base.Awake();
        handCollider[0].enabled = false;
        handCollider[1].enabled = false;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    
    public void OnAttack()
    {
        handCollider[0].enabled = true;
        handCollider[1].enabled = true;
    }
    
    public override void OffAttack()
    {
        base.OffAttack();
        handCollider[0].enabled = false;
        handCollider[1].enabled = false;
    }
    
    public override void SetAttack()
    {
        base.SetAttack();
        SetAnimation("AttackType",Random.Range(0, _attackType));
        OnAttack();
    }
}
