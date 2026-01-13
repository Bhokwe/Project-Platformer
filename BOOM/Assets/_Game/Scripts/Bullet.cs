using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Speed Settings")]
    [SerializeField] float speed = 20f;
    [SerializeField] private int damage = 10;

    private Rigidbody2D rb;
    



    void Start()
    {
       //Rigidbody2D reference
        rb = GetComponent<Rigidbody2D>();
        if ( rb != null )
            rb.gravityScale = 0;

        //Set the bullet's velocity to move to the right
        rb.linearVelocity = transform.right * speed;
        //BulletDirection(this);

        //Destroy the bullet after 2 seconds to avoid memory leaks
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Debug.Log("Bullet collided with " + hitInfo.name);
        //Destroy the bullet on collision with any object
        Destroy(gameObject);
    }

   

}
