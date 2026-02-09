using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    private Rigidbody2D rBody;
    private PlayerControls controls;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public float bulletSpeed;

    private PlayerMovement movementScript;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovement>();
        controls = new PlayerControls();

        controls.player.shoot.performed += ctx => Shoot();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void Shoot()
    {
        bulletOrigin = this.transform;
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpeed * movementScript.lastMoveInput;

    }
}
