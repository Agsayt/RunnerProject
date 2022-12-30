using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : ScriptableObject
{
    public new string name;
    float cooldownTime;
    float activeTime;


    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public virtual void Activate(GameObject gameObject) { }
}
