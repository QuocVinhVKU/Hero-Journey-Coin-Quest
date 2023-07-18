using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    moving,
    dead,
    hurt,
    idle,
    jump,
    attacking,
}
public class Player : MonoBehaviour
{
    public static Player instance;

    private PlayerState playerState;

    [Header("PlayerStats")]
    [SerializeField] float playerHp;
    public float playerAtk;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerJumpForce;

    //Player logic
    private bool isOnGround;
    bool rightPressed, leftPressed, jumpPressed;
    bool isJump;
    bool animFallGround;

    [SerializeField] GameObject skill_4;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private void Awake()
    {
        instance = this;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    private void Start()
    {
        skill_4.SetActive(false);
    }
    
    private void Update()
    {
        //PlayerMovement();
        //Jump();
        if (rightPressed)
        {
            PlayerMovement(1f);
        }
        if (leftPressed)
        {
            PlayerMovement(-1f);
        }
        playerAnim.SetFloat("yVelocity", playerRb.velocity.y);
        if ((!rightPressed && !leftPressed && !jumpPressed)) 
        {
            playerAnim.SetBool("moving", false);
            playerState = PlayerState.idle;
        }


    }
    public void RightButton(bool _rightPressed)
    {
        
        leftPressed = false;
        jumpPressed = false;
        rightPressed = _rightPressed;
    }
    public void LeftButton(bool _leftPressed)
    {
        rightPressed = false;
        jumpPressed = false;
        leftPressed = _leftPressed;
    }

    public void JumpButton(bool _jumpPressed)
    {
        leftPressed = false;
        rightPressed = false;
        jumpPressed = _jumpPressed;
        Jump();
    }
    protected void PlayerMovement(float posX)
    {
        if(playerState != PlayerState.attacking && playerRb.velocity.y <= 0)
        {
            playerState = PlayerState.moving;

            Vector3 movement = new Vector3(posX, 0, 0) * playerSpeed * Time.deltaTime;
            playerRb.transform.position += movement;

            playerAnim.SetBool("moving", true);

            if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
    public void Jump()
    {
        //AudioManager.Instance.JumpAudio();
        if (isOnGround)
        {
            playerState = PlayerState.jump;
            isJump = true;
            playerAnim.SetBool("jump", true);
            playerRb.velocity = Vector2.up * playerJumpForce;
        }

       
    }
    IEnumerator DelayFallGround()
    {
        animFallGround = true;
        yield return new WaitForSeconds(0.25f);
        animFallGround = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            isJump = false;
            playerAnim.SetBool("jump", false);
            if (!rightPressed && !leftPressed)
            {
                playerState = PlayerState.idle;
            }
            StartCoroutine(DelayFallGround());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
    public void Skill_1()
    {
        if (playerState != PlayerState.attacking && animFallGround == false && isOnGround)
        {
            playerState = PlayerState.attacking;

            playerAnim.SetBool("attack_skill_1", true);
            StartCoroutine(WaitFor_Skill_1_Animation());
        }
        
    }
    IEnumerator WaitFor_Skill_1_Animation()
    {
        //lengh animation: 1.5s
        yield return new WaitForSeconds(0.583f);
        playerAnim.SetBool("attack_skill_1", false);
        playerState = PlayerState.idle;
    }
    public void Skill_2()
    {
        if (playerState != PlayerState.attacking && animFallGround == false && isOnGround)
        {
            playerState = PlayerState.attacking;

            playerAnim.SetBool("attack_skill_2", true);
            StartCoroutine(WaitFor_Skill_2_Animation());
        }
        
    }
    IEnumerator WaitFor_Skill_2_Animation()
    {
        //lengh animation: 1.5s
        yield return new WaitForSeconds(0.583f);
        playerAnim.SetBool("attack_skill_2", false);
        playerState = PlayerState.idle;
    }
    public void Skill_3()
    {
        if (playerState != PlayerState.attacking && animFallGround == false && isOnGround)
        {
            playerState = PlayerState.attacking;

            playerAnim.SetBool("attack_skill_3", true);
            StartCoroutine(WaitFor_Skill_3_Animation());
        }
    }
    IEnumerator WaitFor_Skill_3_Animation()
    {
        //lengh animation: 1.5s
        yield return new WaitForSeconds(0.3f);
        playerAnim.SetBool("attack_skill_3", false);
        playerState = PlayerState.idle;
    }
    public void Skill_4()
    {
        if (playerState != PlayerState.attacking && animFallGround == false && isOnGround)
        {
            playerState = PlayerState.attacking;

            skill_4.SetActive(true);
            playerAnim.SetBool("attack_skill_4", true);
            StartCoroutine(WaitFor_Skill_4_Animation());
        }
    }
    IEnumerator WaitFor_Skill_4_Animation()
    {
        //lengh animation: 1.5s
        yield return new WaitForSeconds(1.5f);
        playerAnim.SetBool("attack_skill_4", false);
        skill_4.SetActive(false);
        playerState = PlayerState.idle;
    }
}
