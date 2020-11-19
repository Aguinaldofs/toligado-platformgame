using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControllerPlayer : MonoBehaviour
{
    Animator    playerAnimator;
    Rigidbody2D playerRigidbody2D;
    CapsuleCollider2D playerCapsuleCollider;
    public Transform playerTransform;
    public CapsuleCollider2D colliderPlayer;
    float currCountdownValue;
    //item a ser jogado
    /*[SerializeField]
    GameObject bola;
    */

    bool isPLayerDead = false;
       

    public bool         jump = false;
    public float        jumpForce;

    public int          numberJumps = 0;
    public int          maximoJumps = 3;

    //Referencia para o inimigo
    //public Transform enemy;

    GameControlScript controllerScript;

    //membros internos da class
    float direcao;
    bool isGrounded;

    //membros internos disponiveis no editor
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        controllerScript = FindObjectOfType<GameControlScript>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();

     /*   InvokeRepeating("JogaBola", 1.0f, 1.0f);
     */
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
                      
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
            {
                print("joystick 1 button " + i);
            }
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y > 25)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, 25);
        }


        if (!isPLayerDead){

            isGrounded = playerCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
            //Define se esta ou não pisando no chão
      
            playerAnimator.SetBool("isGrounded", isGrounded);

            direcao = Input.GetAxis("Horizontal"); // Sabe qual a direcao eu estou indo, direita 1 esquerda -1 parado 0
                                                      //Debug.Log(direcao);
            ExecutaMovimentos();
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                jump = false;
            }
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Joystick1Button0))        //&& isGrounded)
            {
                jump = true;
            }
        }

        if (colliderPlayer.IsTouchingLayers(LayerMask.GetMask("portal"))){
            playerTransform.position = new Vector3(-72.9f, -34.3f, 0);
        }
        

        }
       

    private void FixedUpdate()
    {

        if (isPLayerDead)
        {
            GameControlScript.health = 3;
            return;
        }
        MovePlayer();

        if (jump)
        {
            JumpPlayer();
        }
    }

    void JumpPlayer()
    {
        if (isGrounded && !isPLayerDead)
        {
            numberJumps = 0;
        }

        if (isGrounded || numberJumps < maximoJumps)
        {
            playerRigidbody2D.AddForce(new Vector2(0f, jumpForce));
            StartCoroutine(timera());
            numberJumps++;
            //isGrounded = false;
        }
        jump = false;
    }

    void ExecutaMovimentos()
    {
        playerAnimator.SetFloat("velocidadeY", playerRigidbody2D.velocity.y);
        playerAnimator.SetBool("Jump", !isGrounded);
        playerAnimator.SetBool("Run",playerRigidbody2D.velocity.x != 0f && isGrounded && !isPLayerDead);

    }

    void MovePlayer()
    {
        playerRigidbody2D.velocity = new Vector2(direcao * speed , playerRigidbody2D.velocity.y);

        if (direcao != 0) {
            FlipSprite();
        }

            /*if(playerRigidbody2D.velocity.x != 0.0f)
            {
                enemy.GetComponent<ControllerEnemy>().playerIsMoving = true;
            }
            else
            {
                enemy.GetComponent<ControllerEnemy>().playerIsMoving = false;
            }
            */

    }
    IEnumerator timera()
    {
        yield return new WaitForSeconds(2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y == 0)
        {
            numberJumps = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Garrafa"))
        {
            //print("Colidiu com a garrafa");
            controllerScript.DeleteHeart();
        }

        if (collision.tag.Equals("EnemyRun"))
        {
            //Chamar alguma animacao para o player mostrar que perdendo vida.
            //Ver o que ta rolando
            playerRigidbody2D.velocity = new Vector2(100.0f, 15f);
            controllerScript.DeleteHeart();
            //print("Empurrou");
        }

        if (collision.tag.Equals("Fumaca"))
        {
            controllerScript.DeleteHeart();
        }
    }

    public void playerMorreu()
    {
        playerAnimator.SetBool("Morreu", true);
        StartCoroutine(StartCountdown());
        isPLayerDead = true;
        jump = false;
        speed = 0f;
    }
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }

    //Metodos miguezao do phil
    /*private void JogaBola()
    {

      /*  Instantiate(bola, transform.position, Quaternion.identity);

    }
    */

    void FlipSprite() {
        transform.localScale = new Vector3(Mathf.Sign(playerRigidbody2D.velocity.x), 1, 1);
    }
}
