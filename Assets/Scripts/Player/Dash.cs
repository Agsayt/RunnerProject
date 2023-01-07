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
    private float thisCooldownTime;
    private float thisActiveTime;

    public override async void Activate(GameObject gameObject)
    {
        thisCooldownTime = cooldownTime;
        thisActiveTime = activeTime;

        switch (state)
        {
            case AbilityState.ready:                
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    base.Activate(gameObject);
                    state = AbilityState.active;
                    DashPl(dashPower, gameObject.GetComponent<Rigidbody2D>());
                }               
                break;
            case AbilityState.active:
                if(thisActiveTime > 0)
                    thisActiveTime -= Time.deltaTime;
                else
                    state = AbilityState.cooldown;
                break;
            case AbilityState.cooldown:
                if (thisCooldownTime > 0)
                    thisCooldownTime -= Time.deltaTime;
                else
                    state = AbilityState.ready;
                break;
        }                 
    }      

    private void DashPl(float dashPower, Rigidbody2D rb)
    {        
        if (Input.GetKey(KeyCode.RightArrow) )
            rb.AddForce(Vector2.right * dashPower);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector2.left * dashPower);                
    }
}
