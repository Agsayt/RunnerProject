using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityBase : ScriptableObject
{
    public float cooldownTime = 3;
    public float activeTime = 3;
    public AbilityState state = AbilityState.ready;

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public virtual void Activate(GameObject gameObject) { }
}
