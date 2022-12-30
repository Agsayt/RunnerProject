using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu]
public class MovePlayer : AbilityBase
{
    public float movementSpeed;

    public override void Activate(GameObject gameObject)
    {
        base.Activate(gameObject);
        float movement = Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(movement, 0) * movementSpeed * Time.deltaTime;
    }   
}
