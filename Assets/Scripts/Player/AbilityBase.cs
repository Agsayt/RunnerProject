using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : ScriptableObject
{
    public float cooldownTime = 0;
    public float activeTime = 0;
    public AbilityState State = AbilityState.ready;

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public virtual void Activate(GameObject gameObject) { }
}
