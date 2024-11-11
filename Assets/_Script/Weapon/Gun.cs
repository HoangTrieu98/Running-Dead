using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private Text ammoCountText;
    [SerializeField] private ParticleSystem bloodVFX;
    [SerializeField] private CharacterControll characterControll;

    public GunData gunData;

    public void SetGunData(GunData data)
    {
        this.gunData = data;
        ammoCountText.text = gunData.currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!characterControll.canShoot)
        {
            return;
        }
      
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            if (gunData.currentAmmo <=0)
            {
                AudioManager.instance.PlayAudioClip(gunData.emptyAudio);
                return;
            }
            Shoot();
            AudioManager.instance.PlayAudioClip(gunData.shotAudio);
            gunData.currentAmmo--;
            ammoCountText.text = gunData.currentAmmo.ToString();
            if (gunData.currentAmmo <= 0)
            {
                return;
            }
        }
    }

    public void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gunData.range))
        {
            Enemycontroll target = hit.transform.GetComponent<Enemycontroll>();
            if (target != null)
            {
                target.TakeDamage(gunData.damage);
                ParticleSystem blood = Instantiate(bloodVFX, hit.point, Quaternion.identity);
                
                Destroy(blood, 0.6f);
                if (hit.collider.gameObject.CompareTag("Head"))
                {
                    target.TakeDamage(gunData.damage * 2);
                    blood.Play();
                    
                    Destroy(blood, 0.6f);

                    Debug.Log("HeadShot");
                }
                if (gunData.force > 0)
                {
                    var rigid = target.GetComponent<Rigidbody>();
                    rigid.AddForce(fpsCam.transform.forward * gunData.force);
                }
            }
            
           GameObject hitEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           Destroy(hitEffect, 0.5f);     
        }
    }

  
}

