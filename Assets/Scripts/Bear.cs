using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bear : Unit
{
    [SerializeField]
    private int lives = 3;
    private float speed = 5.0F;
    [SerializeField]
    private float jumpForce = 1.0F;
    private bool isGrounded = false;
    new private Rigidbody2D rigidbody;
    Rigidbody2D rb;
    protected Animator animator;
    float speedX;
    public float horizontalSpeed;
    private SpriteRenderer sprite;
    public HP lv;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 3) lives = value;
            lv.Refresh();
        }
    }


    public void Start(){
	rb = GetComponent<Rigidbody2D>();
	animator = GetComponent<Animator>();
    }

    public void RunRight(){
    speedX = horizontalSpeed;
    sprite.flipX = false;
    if (isGrounded) State = CharState.Run;
    }

    public void RunLeft(){
    speedX = -horizontalSpeed;
    sprite.flipX = true;
    if (isGrounded) State = CharState.Run;
    }

    public void Stop(){
        speedX = 0;
        }


    private void Awake()
    {
        lv = FindObjectOfType<HP>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
    void FixedUpdate()
    {
        CheckGround();
	transform.Translate(speedX, 0, 0);
    }
    void Update()
    {
        if (isGrounded) State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }
    void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
        if (isGrounded) State = CharState.Run;
    }
    public override void ReceiveDamage()
    {
        Lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
        if (Lives <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Jump()
    {
	if(isGrounded) 
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.7F);
        isGrounded = colliders.Length > 1;
        if (!isGrounded) State = CharState.Jump;
    }
}
public enum CharState
{
    Idle,
    Run,
    Jump
}