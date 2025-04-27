using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] int currentPosition = 0;

    Rigidbody2D playerRb;
    BoxCollider2D playerFeetCollider;
    private bool isFacingRight = true;


    [Header("Animations and Effects")]
    public Animator playerAnim;
 

    [Header("Player Audio")]
    AudioSource playerAudioSource;
    public AudioClip jumpSound;
    public float jumpVolume;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath();
        Flip();
        ButtonManager();
    }

    void OnControl(InputValue input)
    {
        if (input.isPressed)
        {
            if(currentPosition == 0)
            {
                currentPosition = 1;
            }
            else if(currentPosition == 1)
            {
                currentPosition = 2;
            }
            else
            {
                currentPosition = 0;
            }
        }
    }

    void Jump()
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (currentPosition == 1)
        {
            playerAnim.SetTrigger("jump");
            playerAudioSource.PlayOneShot(jumpSound, jumpVolume);
            playerRb.velocity = new Vector2(0, jumpSpeed);
        }
    }


    void Flip()
    {

        if (playerRb.velocity.x < 0 && isFacingRight == true)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isFacingRight = false;
        }
        else if (playerRb.velocity.x > 0 && isFacingRight == false)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isFacingRight = true;
        }

    }

    void ButtonManager()
    {
        if(currentPosition == 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y);
        }

        if(currentPosition == 1)
        {
            Jump();
        }

        if(currentPosition == 2)
        {
   
            playerAnim.SetBool("isRunning", true);
            playerRb.velocity = new Vector2(-playerSpeed, playerRb.velocity.y);
        }
    }

    void PlayerDeath()
    {
        if(transform.position.y < -11f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
