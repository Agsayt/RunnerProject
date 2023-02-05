using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityBase : ScriptableObject
{
    
    public AbilityState state = AbilityState.ready;
    private float coolDownTime;
    private float activeTime;    
    
    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public virtual void Activate(GameObject gameObject) { }
}
