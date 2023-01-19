using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Dash", menuName = "PlayerAbilities/Dash", order = 1)]
public class Dash : AbilityBase
{    
    public float dashPower;
    private float coolDown = 5;

    public override async void Activate(GameObject gameObject)
    {        
        switch (state)
        {
            case AbilityState.ready:                
                if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
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
                    cooldownTime -= Time.deltaTime;
                else
                {
                    state = AbilityState.ready;
                    cooldownTime = coolDown;
                }
                break;
        }
    }

    private void DashPl(float dashPower, Rigidbody2D rb)
    {
        coolDown = cooldownTime;
        if (Input.GetKey(KeyCode.RightArrow) )
            rb.AddForce(Vector2.right * dashPower);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector2.left * dashPower);                
    }
}
