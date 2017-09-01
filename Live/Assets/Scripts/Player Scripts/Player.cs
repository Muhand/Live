using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public float maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myBody;
    [SerializeField]
    private Animator anim;

    void Awake()
    {
        //If myBody initialization was forgotten then auto get the rigitbody
        if(myBody == null)
            myBody = GetComponent<Rigidbody2D>();

        if (anim == null)
            anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard() {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");           //Returns -1 for left and 1 for right
        
        if(h>0)
        {
            if (vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        } else if (h < 0)
        {
            if (vel < maxVelocity)
                forceX = -speed;                            //Set speed to negative in order to go to the left

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
            anim.SetBool("Walk", false);

        myBody.AddForce(new Vector2(forceX, 0));
    }

} // Player