using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/* its all text now
//only put this script on shooter enemies
public class Enemyshooting : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject playerTarget;

    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

    public float bulletSpeed = 15f;

    public float fireRate = 0.3f;

    public float damage = 1f;

    public bool justFired = false;

    Vector2 shootdir;

    public LayerMask targetLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            Shoot();
            yield return new WaitForSeconds(3);
        }

        void Shoot()
        {

            Vector3 target = playerTarget.transform.position;

            // Calculate the direction from the player to the mouse
            Vector3 direction = mouseposFixed - bulletSpawnPoint.transform.position;

            // Calculate the angle in degrees cuz u know
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //why the fyuck does it need to bee a quaternion - ahhhh:-(
            quaternion angleFixed = Quaternion.Euler(0, 0, angle);

            // Calculate the angle from the last movement direction
            float angle = Mathf.Atan2(shootdir.y, shootdir.x) * Mathf.Rad2Deg;

            // Create a rotation quaternion based on this angle
            angleFixed = Quaternion.Euler(0, 0, angle);

            shootdir = Vector2.zero;

            // Spawn the bullet object
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, angleFixed);

            // Attach a script to the bullet to handle movement and raycast and cool shit
            bullet.AddComponent<BulletMovement>().Initialize(bulletSpeed, targetLayer, damage);
        }
    }
}*/