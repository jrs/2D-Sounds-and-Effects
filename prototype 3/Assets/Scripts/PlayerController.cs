using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public bool isOnGround = false;
    public bool isGameOver = false;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody2D _playerRB;
    private Animator _playerAnim;
    private AudioSource _playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !isGameOver)
        {
            _playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            _playerAnim.SetBool("IsOnGround", false);
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            _playerAnim.SetBool("IsOnGround", true);
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            _playerAnim.SetTrigger("IsHit");
            _playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
