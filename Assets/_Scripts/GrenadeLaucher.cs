using UnityEngine;

public class GrenadeLaucher : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firePos;
    public float bulletSpeed;
    public AudioSource shootingSound;

    public AutoShooting autoShooting;


    private void Update()
    {
        if(Input.GetMouseButtonDown(LeftMouseButton))
        {
            ShootBullet();
        }        
    }
    public void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        bullet.GetComponent<Rigidbody>().velocity -= firePos.forward * bulletSpeed;

        shootingSound.Play();
        
        Destroy(bullet, 1.2f);
    }
}
