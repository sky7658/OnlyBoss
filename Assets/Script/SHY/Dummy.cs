using System;
using System.Collections;
using System.Collections.Generic;
using Script.SHY.General;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamgeable>().TakeHit(10, this.transform);
    }
}
