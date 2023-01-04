using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEvent : UnityEvent
{
    [SerializeField] public InvokeTypes InvokeType;
    [SerializeField] public GameObject Source;
    [SerializeField] public EventTypes Type;
}
