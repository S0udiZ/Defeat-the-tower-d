using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponShoot : MonoBehaviour
{
    public Rigidbody2D rb;

    public Camera cam;
    public Vector3 mouseposFixed;

    // Where should the bullet spawn
    public Transform bulletSpawnPoint;

    // Bullet prefab
    public GameObject bulletPrefab;

    // Reference to the layer you want the Raycast to interact with (optional)
    public LayerMask targetLayer;

    // Bullet speed
    float bulletSpeed = 20f;

    float fireRate = 0.1f;

    float damage = 1f;

    public bool justFired = false;


    public bool usingdirShooting = true;


    private Vector2 lastMovementDirection;
    quaternion oldRotation;
    Quaternion angleFixed;

    Vector2 shootdir;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (usingdirShooting)
        {
            // Get the player's current movement direction (assuming it's based on velocity)
            Vector2 currentDirection = rb.velocity;

            // Update lastMovementDirection if the player is moving
            if (currentDirection != Vector2.zero)
            {
                lastMovementDirection = currentDirection.normalized;
            }

            // Check if the player presses the fire button (usually the left mouse button or a specific key)
            if (Input.GetButtonDown("Fire1") && !justFired)
            {
                Shoot();
                justFired = true;
                StartCoroutine(WaitAndAllowShoot(fireRate));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !justFired)
            {
                justFired = true;
                shootdir = Vector2.up;
                Shoot();
                StartCoroutine(WaitAndAllowShoot(fireRate));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !justFired)
            {
                justFired = true;
                shootdir = Vector2.down;
                Shoot();
                StartCoroutine(WaitAndAllowShoot(fireRate));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !justFired)
            {
                justFired = true;
                shootdir = Vector2.left;
                Shoot();
                StartCoroutine(WaitAndAllowShoot(fireRate));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !justFired)
            {
                justFired = true;
                shootdir = Vector2.right;
                Shoot();
                StartCoroutine(WaitAndAllowShoot(fireRate));
            }


        }

        void Shoot()
        {
            /*
            Vector3 mousepos = Input.mousePosition;

            Vector3 mouseposWorld = cam.ScreenToWorldPoint(mousepos);

            mouseposFixed = new Vector3(mouseposWorld.x, mouseposWorld.y, 0);

            // Calculate the direction from the player to the mouse
            Vector3 direction = mouseposFixed - bulletSpawnPoint.transform.position;

            // Calculate the angle in degrees cuz u know
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //why the fyuck does it need to bee a quaternion - ahhhh:-(
            quaternion angleFixed = Quaternion.Euler(0, 0, angle);


            old code for 360 shooting
            */

            if (usingdirShooting)
            {
                // Calculate the angle from the last movement direction
                float angle = Mathf.Atan2(lastMovementDirection.y, lastMovementDirection.x) * Mathf.Rad2Deg;

                // Create a rotation quaternion based on this angle
                angleFixed = Quaternion.Euler(0, 0, angle);
            }
            else if (!usingdirShooting) 
            {
                // Calculate the angle from the last movement direction
                float angle = Mathf.Atan2(shootdir.y, shootdir.x) * Mathf.Rad2Deg;

                // Create a rotation quaternion based on this angle
                angleFixed = Quaternion.Euler(0, 0, angle);
            }

            // Spawn the bullet object
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, angleFixed);

            // Attach a script to the bullet to handle movement and raycast and cool shit
            bullet.AddComponent<BulletMovement>().Initialize(bulletSpeed, targetLayer, damage);
        }
        IEnumerator WaitAndAllowShoot(float tTime)
        {
            yield return new WaitForSeconds(tTime);
            justFired = false;
        }
    }

    public class BulletMovement : MonoBehaviour
    {
        private float bulletSpeed;
        private float damage;
        private LayerMask targetLayer;
        private Vector2 previousPosition;
        public Enemybase enemybase;

        // Initialize the bullet's speed and target layer
        public void Initialize(float speed, LayerMask layer, float newdamage)
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
                // Debug log to show what was hit
                Debug.Log("Hit: " + hit.collider.name);
                if (hit.collider.CompareTag("enemy"))
                {
                    enemybase = hit.collider.gameObject.GetComponent<Enemybase>();
                    if (enemybase != null)
                    {
                        enemybase.TakeDamage(damage);
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
}
