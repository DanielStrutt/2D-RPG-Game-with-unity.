using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Constants 
    private string HORIZONTAL = "Horizontal";
    private string VERTICAL = "Vertical";
    private string ATTACK = "Attack";

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;

    private bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D myRigidbody;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    // Update is called once per frame
    void Update()
    {

        playerMoving = false;

        if (!attacking)
        {
            if (Input.GetAxisRaw(HORIZONTAL) > 0.5f || Input.GetAxisRaw(HORIZONTAL) < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw(HORIZONTAL) * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw(HORIZONTAL) * moveSpeed, 0f);
            }

            if (Input.GetAxisRaw(VERTICAL) > 0.5f || Input.GetAxisRaw(VERTICAL) < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw(VERTICAL) * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw(VERTICAL));
            }

            if (Input.GetAxisRaw(HORIZONTAL) < 0.5f && Input.GetAxisRaw(HORIZONTAL) > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw(VERTICAL) < 0.5f && Input.GetAxisRaw(VERTICAL) > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            //f(Input.GetKeyDown(KeyCode.J))
            if (Input.GetKeyDown(KeyCode.JoystickButton1)|| Input.GetKeyDown(KeyCode.Mouse1))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool(ATTACK, true);
            }

            if (Mathf.Abs(Input.GetAxisRaw(HORIZONTAL)) > 0.5f && (Mathf.Abs(Input.GetAxisRaw(VERTICAL)) > 0.5f))
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }          
        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool(ATTACK, false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw(HORIZONTAL));
        anim.SetFloat("MoveY", Input.GetAxisRaw(VERTICAL));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
