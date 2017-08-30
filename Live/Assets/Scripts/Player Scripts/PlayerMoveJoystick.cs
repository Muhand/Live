using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {
    public float speed = 8f;
    public float maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myBody;
    [SerializeField]
    private Animator anim;

    private bool moveLeft, moveRight;

    void Awake()
    {
        //If myBody initialization was forgotten then auto get the rigitbody
        if (myBody == null)
            myBody = GetComponent<Rigidbody2D>();

        if (anim == null)
            anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moveLeft)
            MoveLeft();
        else if (moveRight)
            MoveRight();
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
        anim.SetBool("Walk", true);
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }

    void MoveLeft () {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = -speed;                            //Set speed to negative in order to go to the left

        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = speed;                            //Set speed to negative in order to go to the left

        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        myBody.AddForce(new Vector2(forceX, 0));
    }

}
