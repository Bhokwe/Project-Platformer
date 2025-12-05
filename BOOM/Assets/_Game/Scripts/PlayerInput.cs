using UnityEngine;
using UnityEngine.Animations;

public class PlayerInput : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    //References to the player's components
    private Rigidbody2D _rb;
    private PlayerWeapon _playerWeapon;

    // Grounded check
    //bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerWeapon script reference
        _playerWeapon = GetComponent<PlayerWeapon>();
        //Rigidbody2D reference
        _rb = GetComponent<Rigidbody2D>();
        //isGrounded checker
        //bool isGrounded = Physics2D.OverlapCircle(new Vector2(0, -1), 0.1f, LayerMask.GetMask("Ground"));

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        HandleShooting();   

    }

    void PlayerMovement()
    {
        //axis inpit receieved from keyboard (horoizontal)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        

        //axis input received from keyboard (horizontal)        
        _rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, _rb.linearVelocity.y);
        //axis input received from keyboard (vertical) (jumping)
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) /*&& isGrounded is true*/) 
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, moveSpeed);
        }


    }
    void HandleShooting()
    {
        //when the space bar is pressed down and the playerWeapon script is attached
                if (Input.GetKeyDown(KeyCode.Space) && _playerWeapon != null)
        {
            _playerWeapon.Shoot();
        }
    }
}