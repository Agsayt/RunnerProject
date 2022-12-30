using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : AbilityBase
{
    private bool lockDash = false;
    public float dashCooldown;
    public float dashPower;

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        if (Input.GetKeyDown(KeyCode.LeftShift) && !lockDash)
            DashPl(dashCooldown, dashPower, gameObject.GetComponent<Rigidbody2D>());
    }
      

    private void DashPl(float timeLockDash, float dashPower, Rigidbody2D rb)
    {
        lockDash = true;
        //Invoke("DashLock", timeLockDash);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(Vector2.right * dashPower);
        else
            rb.AddForce(Vector2.left * dashPower);
    }

    private void DashLock()
    {
        lockDash = false;
    }
}
