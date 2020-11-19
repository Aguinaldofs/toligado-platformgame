using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour
{
    private bool checkTrigger;
    public float speed;
    public Transform target;

    private Animator PlayerAnimator;
    private Rigidbody2D playerRigidbody2D;
    public Transform groundCheck;

    public bool isGrounded;
    public bool facingRight = true;

    public float direcao;

    public bool jump = false;
    public float jumpForce;

    //GAMBI DO PHIL
    public bool playerIsMoving = false;

    ControllerPlayer p1 = new ControllerPlayer();

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x,
                                                                                    transform.position.y),
                                                                                    speed * Time.deltaTime);


        //isGrounded = Physics2D.Linecast(transform.position, groundCheck.position,1<<LayerMask.NameToLayer("Ground"));
        //PlayerAnimator.SetBool("Run", playerRigidbody2D.velocity.x != 0f);
        isGrounded = true;
        //Define se esta ou não pisando no chão
        Debug.Log(isGrounded);
        PlayerAnimator.SetBool("isGrounded",isGrounded);

        direcao = Input.GetAxisRaw("Horizontal"); // Sabe qual a direcao eu estou indo, direita 1 esquerda -1 parado 0
        Debug.Log(direcao);
        ExecutaMovimentos();

        if (Input.GetButtonDown("Jump") )        //&& isGrounded)
        {
            jump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void ExecutaMovimentos()
    {
        //PlayerAnimator.SetBool("Jump", !isGrounded);
        //PlayerAnimator.SetBool("Run", playerRigidbody2D.velocity.x != 0f && isGrounded);
        PlayerAnimator.SetBool("Run", playerIsMoving && isGrounded);
        print(target);
       

    }
    void MovePlayer(float movimentoH)
    {
        playerRigidbody2D.velocity = new Vector2(movimentoH * speed, playerRigidbody2D.velocity.y);
        if (movimentoH < 0 && facingRight || (movimentoH > 0 && !facingRight))
        {
            Flip();
        }
    }
}