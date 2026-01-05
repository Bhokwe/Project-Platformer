using UnityEngine;
using UnityEngine.Animations;

public class PlayerInput : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    //References to the player's components
    private Rigidbody2D _rb;
    private PlayerWeapon _playerWeapon;

    
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    
    void Start()
    {
        //playerWeapon script reference
        _playerWeapon = GetComponent<PlayerWeapon>();
        //Rigidbody2D reference
        _rb = GetComponent<Rigidbody2D>();
        

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


        //checking the direction of the playere's movement to flip the sprite
        if (horizontalInput > 0) 
        { 
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else if (horizontalInput < 0) 
        { 
            transform.localScale = new Vector3(-1, 1, 1);
            

        }
        //axis input received from keyboard (vertical) (jumping)
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded()) 
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

    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize);
    }
}