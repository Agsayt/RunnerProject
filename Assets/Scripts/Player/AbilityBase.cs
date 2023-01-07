using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityBase : ScriptableObject
{
    
    public AbilityState state = AbilityState.ready;
    public float cooldownTime = 5;
    public float activeTime = 0;    
    
    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public virtual void Activate(GameObject gameObject) { }
}
