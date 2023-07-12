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
    [SerializeField] float speed;
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
        PlayerMovement();
    }
    protected void PlayerMovement()
    {
        if(playerState != PlayerState.attacking)
        {
            playerState = PlayerState.moving;
            //move player position and change animation         
            float moveHor = InputManager.Instance.PlayerMoveInput();
            Vector3 movement = new Vector3(moveHor, 0, 0) * speed * Time.deltaTime;
            playerRb.transform.position += movement;

            //change animation         
            if (movement.magnitude > 0)
            {
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
            else
            {
                playerAnim.SetBool("moving", false);
            }

        }
    }
    public void Skill_1()
    {
        if(playerState != PlayerState.attacking)
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
        if(playerState != PlayerState.attacking)
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
        if (playerState != PlayerState.attacking)
        {
            playerState = PlayerState.attacking;

            playerAnim.SetBool("attack_skill_3", true);
            StartCoroutine(WaitFor_Skill_3_Animation());
        }
    }
    IEnumerator WaitFor_Skill_3_Animation()
    {
        //lengh animation: 1.5s
        yield return new WaitForSeconds(0.583f);
        playerAnim.SetBool("attack_skill_3", false);
        playerState = PlayerState.idle;
    }
    public void Skill_4()
    {
        if (playerState != PlayerState.attacking)
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
