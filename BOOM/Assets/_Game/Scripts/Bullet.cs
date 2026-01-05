using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Speed Settings")]
    float speed = 20f;
    
    private Rigidbody2D _rb;
    private Bullet bullet; 
    private PlayerWeapon _playerWeapon;
    

    void Start()
    {
       //Rigidbody2D reference
        _rb = GetComponent<Rigidbody2D>();
        if ( _rb != null )
            _rb.gravityScale = 0;

        //Set the bullet's velocity to move to the right
        _rb.linearVelocity = transform.right * speed;
        //BulletDirection(this);

        //Destroy the bullet after 2 seconds to avoid memory leaks
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collided with " + collision.name);
        //Destroy the bullet on collision with any object
        Destroy(gameObject);
    }

    void BulletDirection(Bullet bullet) 
    { 
        if (bullet.transform.localScale.x > 0)
        {
            //shoot right
            _rb.linearVelocity = transform.right * speed;
        }
        else if (bullet.transform.localScale.x < 0) 
        {
            //shoot left
            _rb.linearVelocity = -transform.right * speed;
        }
    }

}
