using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity SO", menuName = "Scriptable Object/Entity SO", order = int.MaxValue)]
public class EntitySO : ScriptableObject
{
    [SerializeField] private string objName;
    public string ObjName { get { return objName; } }

    [SerializeField] private float maxHP;
    public float MaxHp { get { return maxHP; } }

    [SerializeField] private float maxDef;
    public float MaxDef { get {  return maxDef; } }

    [SerializeField] private float originDef;
    public float OriginDef { get { return originDef; } }

    [SerializeField] private float originAtk;
    public float OriginAtk { get {  return originAtk; } }

    [SerializeField] private float maxAtk;
    public float MaxAtk { get { return maxAtk; } }

    [SerializeField] private float maxSpeed;
    public float MaxSpeed { get {  return maxSpeed; } }
}
