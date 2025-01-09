using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemyshooting : MonoBehaviour
{
    public Rigidbody2D rb;

    // Where should the bullet spawn
    public Transform bulletSpawnPoint;

    // Bullet prefab
    public GameObject bulletPrefab;

    // Reference to the layer you want the Raycast to interact with (optional)
    public LayerMask targetLayer;

    // Bullet speed
    float bulletSpeed = 12f;

    public float fireRate = 4;

    int damage = 1;

    public bool justFired = false;

    public GameObject player;


    //public bool usingdirShooting = false;


    private Vector2 lastMovementDirection;
    quaternion oldRotation;
    Quaternion angleFixed;

    Vector2 shootdir;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(shootdelay());
    }

    void Update()
    {
        if (!justFired)
        {
            Shoot();
        }
    }

        void Shoot()
        {

            /*
            player = GameObject.FindWithTag("Player");

            // Calculate the direction from the player to the mouse
            Vector3 direction = player.gameObject.transform.position - bulletSpawnPoint.transform.position;

            // Calculate the angle in degrees cuz u know
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //why the fyuck does it need to bee a quaternion - ahhhh:-(
            quaternion angleFixed = Quaternion.Euler(0, 0, angle);

            

            // Spawn the bullet object
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, angleFixed);

            // Attach a script to the bullet to handle movement and raycast and cool shit
            bullet.AddComponent<BulletMovement>().Initialize(bulletSpeed, targetLayer, damage);
            */
        }
        IEnumerator WaitAndAllowShoot(float tTime)
        {
            yield return new WaitForSeconds(tTime);
            justFired = false;
        }

    //this Enumerator just makses a cooldown with "fireRate" and puts in in front of the entire shoot part of the script
        IEnumerator shootdelay()
        {
        yield return new WaitForSeconds(fireRate);
        player = GameObject.FindWithTag("Player");

        // Calculate the direction from the player to the mouse
        Vector3 direction = player.gameObject.transform.position - bulletSpawnPoint.transform.position;

        // Calculate the angle in degrees cuz u know
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //why the fyuck does it need to bee a quaternion - ahhhh:-(
        quaternion angleFixed = Quaternion.Euler(0, 0, angle);

        bulletPrefab.transform.rotation = angleFixed;

        // Spawn the bullet object
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, angleFixed);

        // Attach a script to the bullet to handle movement and raycast and cool shit
        bullet.AddComponent<BulletMovement>().Initialize(bulletSpeed, targetLayer, damage);
        StartCoroutine(shootdelay());
        }
}

    public class BulletMovement : MonoBehaviour
    {
        private float bulletSpeed;
        private int damage;
        private LayerMask targetLayer;
        private Vector2 previousPosition;
        public playercontroller playerController;

        // Initialize the bullet's speed and target layer
        public void Initialize(float speed, LayerMask layer, int newdamage)
        {
            bulletSpeed = speed;
            targetLayer = layer;
            damage = newdamage;
            previousPosition = transform.position;
        }

        void Update()
        {
            // Calculate the current position
            Vector2 currentPosition = transform.position;

            // Calculate the direction the bullet is moving in
            Vector2 direction = (currentPosition - previousPosition).normalized;

            // Perform the Raycast from the previous position to the current position
            RaycastHit2D hit = Physics2D.Raycast(previousPosition, direction, Vector2.Distance(previousPosition, currentPosition), targetLayer);

            // Check if the Raycast hits something
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerController = hit.collider.gameObject.GetComponent<playercontroller>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(damage);
                    }
                }

                // Destroy the bullet
                Destroy(gameObject);

                // Optionally destroy the object that was hit (if applicable)
                // Destroy(hit.collider.gameObject);
            }

            // Visualize the Raycast in the editor for debugging purposes
            Debug.DrawRay(previousPosition, direction * Vector2.Distance(previousPosition, currentPosition), Color.red, 1f);

            // Update the previous position to the current position
            previousPosition = currentPosition;

            // Move the bullet forward
            transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        }

    }
