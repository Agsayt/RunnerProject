using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
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
    PlayerController playerController;
    Dash dash;
    private float cooldownTime;
    private float activeTime;
    private AbilityBase.AbilityState state;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;

        playerController = gameObject.GetComponent<PlayerController>();
        dash = (playerController.abilities.Find(x => x.name.Contains("Dash")) as Dash);
        cooldownTime = dash.cooldownTime;
        state = dash.state;
        activeTime = dash.activeTime;
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

        dash.cooldownTime = cooldownTime;
        dash.state = state;
        dash.activeTime = activeTime;
    }

    public void PlayerRevive() => isAlive = true;
}
