using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLookAtMouse : MonoBehaviour
{
    public float speed = 15f;
    public float jumpForce = 5f;
    private bool isMoving = false;
    private bool isJumping = false;
    private Vector3 moveDirection;

    private Camera mainCamera;
    private bool hasJumped = false;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for button press
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;

            // Get the mouse position
            Vector3 mousePosition = Input.mousePosition;
            // Convert the mouse position from screen coordinates to world coordinates
            Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));

            // Get the direction vector from the circle to the mouse
            moveDirection = transform.position - worldMousePosition;
            moveDirection.Normalize();

            // Check if the mouse is at the bottom of the screen
            if (mousePosition.y < Screen.height * 0.2f && !hasJumped && canJump)
            {
                isJumping = true;
                hasJumped = true;
                canJump = false;
            }
        }

        // Check for button release
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        // Move the circle if the button is pressed
        if (isMoving)
        {
            // Calculate the new position for moving the circle
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

            // Update the circle's position
            transform.position = newPosition;
        }


        //изменение размера
        var sizeX = transform.localScale.x;
        var sizeY = transform.localScale.y;


        this.transform.localScale = new Vector3(
            (int)ProgressBar.sizeCat / 10 * sizeX,
            (int)ProgressBar.sizeCat / 10 * sizeY,
            0f);
    }


    private void FixedUpdate()
    {
        // Apply jumping force if necessary
        if (isJumping)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enable jumping when the circle lands on the surface
        if (collision.contacts[0].normal.y > 0.5f)
        {
            hasJumped = false;
            canJump = true;
        }
    }


}
