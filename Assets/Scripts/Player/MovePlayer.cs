using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Movement", menuName = "PlayerAbilities/Movement", order = 1)]
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
