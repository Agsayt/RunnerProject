using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
        
    Rigidbody2D rb;

    [SerializeField] float speed = 1;
    [SerializeField] float jump = 2;
    [SerializeField] float Dashpower = 5;
    [SerializeField] float timeLockDask = 2;
    private bool lockDash = false;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Dash();

    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0) * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05)
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !lockDash)
        {
            lockDash = true;
            Invoke("DashLock", timeLockDask);
            if (Input.GetKey(KeyCode.RightArrow))
                rb.AddForce(Vector2.right * Dashpower);
            else
                rb.AddForce(Vector2.left * Dashpower);
        }            
    }

    void DashLock()
    {
        lockDash = false;
    }

    private void Slide()
    {

    }


}
