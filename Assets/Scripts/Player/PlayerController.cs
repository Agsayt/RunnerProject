using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    private bool isAlive;

    [SerializeField] public List<AbilityBase> abilities;
    public PlayerStates playerStates;
    public UnityEvent dieEvent;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }
    
    void Update()
    {
        if (isAlive)
        {
            foreach (var ability in abilities)
            {            
                ability.Activate(gameObject);
            }
        }
    }

    public bool IsPlayerAlive() => isAlive;


    public void Die()
    {
        isAlive = false;
        dieEvent.Invoke();
    }

    public void PlayerRevive() => isAlive = true;
}
