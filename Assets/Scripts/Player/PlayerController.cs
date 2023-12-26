using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateSO curState;
    public PlayerStateSO remainState;

    void Update()
    {
        curState.UpdateState(this);
    }
    
    public void TransitionToState(PlayerStateSO nextState)
    {
        if(nextState != remainState) curState = nextState;
    }
}
