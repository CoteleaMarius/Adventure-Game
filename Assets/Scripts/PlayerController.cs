using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private Vector2 _direction;
    private Rigidbody2D _playerRb;
    private SpriteRenderer _playerSprite;
    private bool _isGrounded = true;
    private Animator _animator;
    private readonly string _isRun = "isRun";
    void Start()
    {
        _playerRb = gameObject.GetComponent<Rigidbody2D>();
        _playerSprite = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Translate(_direction * (speed * Time.deltaTime));
        PlayerAnimation();
        PlayerJump();
    }

    void PlayerAnimation()
    {
        if (_direction.x > 0)
        {
            _playerSprite.flipX = false;
        }
        else if (_direction.x < 0)
        {
            _playerSprite.flipX = true;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_isRun, true);
        }
        else
        {
            _animator.SetBool(_isRun, false);
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _animator.Play("Crouch");
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _animator.Play("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}