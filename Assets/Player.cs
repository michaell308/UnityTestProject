using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveInput;
    private bool isWDown;
    private float speed = 400;
    private float jumpHeight = 8;
    private Rigidbody2D rb;
    private Vector2 feetBoxSize = new Vector2(0.5f, 0.5f);
    public Transform feetPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y);
    }

    private void GetInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        isWDown = Input.GetKeyDown(KeyCode.W);
    }

    private void Jump()
    {
        bool isGrounded = Physics2D.OverlapBox(feetPos.position, feetBoxSize, 0, LayerMask.GetMask("Ground"));
        if (isWDown && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
