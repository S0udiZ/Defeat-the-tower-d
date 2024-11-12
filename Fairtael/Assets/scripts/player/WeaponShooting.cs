using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public Camera cam;
    public Vector3 mouseposFixed;

    // Where should the bullet spawn
    public Transform bulletSpawnPoint;

    // Bullet prefab
    public GameObject bulletPrefab;

    // Reference to the layer you want the Raycast to interact with (optional)
    public LayerMask targetLayer;

    // Bullet speed
    float bulletSpeed = 70f;

    float fireRate = 0.1f;

    public bool justFired = false;

    void Update()
    {
        // Check if the player presses the fire button (usually the left mouse button or a specific key)
        if (Input.GetButtonDown("Fire1") && !justFired)
        {
            Shoot();
            justFired = true;
            StartCoroutine(WaitAndAllowShoot(fireRate));
        }
    }

    void Shoot()
    {
        Vector3 mousepos = Input.mousePosition;

        Vector3 mouseposWorld = cam.ScreenToWorldPoint(mousepos);

        mouseposFixed = new Vector3(mouseposWorld.x, mouseposWorld.y, 0);

        // Calculate the direction from the player to the mouse
        Vector3 direction = mouseposFixed - bulletSpawnPoint.transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        quaternion angleFixed = Quaternion.Euler(0, 0, angle);

        // Spawn the bullet object
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, angleFixed);

        // Attach a script to the bullet to handle movement and raycasting
        bullet.AddComponent<BulletMovement>().Initialize(bulletSpeed, targetLayer);
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
    private LayerMask targetLayer;
    private Vector2 previousPosition;

    // Initialize the bullet's speed and target layer
    public void Initialize(float speed, LayerMask layer)
    {
        bulletSpeed = speed;
        targetLayer = layer;
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
