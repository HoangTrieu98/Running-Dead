using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour
{
    [SerializeField] private int[] listWeaponId;
    
     
    void Update()
    {
       
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var weaponSwitching = collision.gameObject.GetComponentInChildren<WeaponSwitching>();

            var randomWeapon = listWeaponId[Random.Range(0, listWeaponId.Length)];
            weaponSwitching.UnlockWeapon(randomWeapon);
           

            Destroy(gameObject);
        }
    }
}
