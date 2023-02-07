using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static MovePlayer;

[CreateAssetMenu(fileName = "Dash", menuName = "PlayerAbilities/Dash", order = 1)]
public class Dash : AbilityBase
{    
    public float dashPower;
    public float cooldownTime = 3;
    public float activeTime = 0;
    private float cooldown;
    private float active;
    DirectionState direction;

    public override async void Activate(GameObject gameObject)
    {
        var playerController = gameObject.GetComponent<PlayerController>();
        if (playerController is null)
            return;
        var movePlayer = (playerController.abilities.Find(x => x.name.Contains("Move")) as MovePlayer);
        direction = movePlayer.direction;

        switch (state)
        {
            case AbilityState.ready:                
                if (Input.GetKeyDown(KeyCode.LeftShift) && (direction is DirectionState.right || direction is DirectionState.left))
                {
                    base.Activate(gameObject);
                    state = AbilityState.active;
                    DashPl(dashPower, gameObject.GetComponent<Rigidbody2D>());
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                    activeTime -= Time.deltaTime;
                else
                    state = AbilityState.cooldown;
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                    activeTime = active;
                }
                else
                {
                    state = AbilityState.ready;
                    cooldownTime = cooldown;
                }
                break;
        }
    }

    private void DashPl(float dashPower, Rigidbody2D rb)
    {
        cooldown = cooldownTime;
        active = activeTime;

        if (direction is DirectionState.right)
            rb.AddForce(Vector2.right * dashPower);
        else if (direction is DirectionState.left)
            rb.AddForce(Vector2.left * dashPower);                
    }
}
