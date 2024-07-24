using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    public int rpm;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public AudioSource shootingSound;

    private float lastShot;
    private float interval;

    public GunMuzzle gunMuzzle;
    
    private void Start()
    {
        interval = 60f / rpm;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            gunMuzzle.ShowMuzzle();
        }
    }

    public void Shoot()
    {
        PerformRaycasting();
        shootingSound.Play();
    }

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);

        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            
            var newhitMarkerPrefab = Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);

            Destroy(newhitMarkerPrefab,0.2f); ;
        }
    }
}
