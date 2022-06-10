using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] private float playerSpeed;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private Vector2 lastMovementDirection;

    //references
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator anim;

    void Update(){
        HandleInput();
    }

    void FixedUpdate(){
        Move();
        Animate();
    }

    void HandleInput(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0){
            lastMovementDirection = moveDirection;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * playerSpeed,
                                moveDirection.y * playerSpeed);
    }

    void Animate(){
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMovementDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMovementDirection.y);
    }
}
