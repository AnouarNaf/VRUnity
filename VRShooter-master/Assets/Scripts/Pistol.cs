using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;
    public int maxAmmo = 6;
    public int currentAmmo = 6;
    [SerializeField] public TMP_Text TextAmmo;
    public int Ammo = 0;
    public float reloadTime;
    private bool isReloading = false;
    AudioSource audioData;


    protected override void StartShooting(XRBaseInteractor interactor)
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0 && Ammo > 0)
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
        Ammo = Ammo - maxAmmo;
        TextAmmo.text = currentAmmo.ToString() + "/" + Ammo;
        isReloading = false;
    }
    protected override void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("No Ammo");
        } else
        {
            currentAmmo--;
            TextAmmo.text = currentAmmo.ToString() + "/" + Ammo;
            base.Shoot();
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            projectileInstance.Init(this);
            projectileInstance.Launch();
        }
        
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
