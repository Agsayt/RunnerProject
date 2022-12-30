using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbilityBase
{
    private bool lockDash = false;

    public void CheckAbility(float speed, float jump, float dashPower, float timeLockDash, GameObject gm)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !lockDash)
            DashPl(timeLockDash, dashPower, gm.GetComponent<Rigidbody2D>());
    }

    private void DashPl(float timeLockDash, float dashPower, Rigidbody2D rb)
    {
        lockDash = true;
        Invoke("DashLock", timeLockDash);
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
