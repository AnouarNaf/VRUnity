using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;
    public int maxAmmo = 6;
    public int currentAmmo = 6;
    public float reloadTime;
    private bool isReloading = false;


    protected override void StartShooting(XRBaseInteractor interactor)
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());      
            return;
        } else
        {
            base.StartShooting(interactor);
            Shoot();
        }
    
        
    }
    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime );

        currentAmmo = maxAmmo;

        isReloading = false;
    }
    protected override void Shoot()
    {
        currentAmmo --;
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
