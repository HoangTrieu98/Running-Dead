using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData
{
    public int weaponId; // dinh danh cho tung vu khi
    public bool isActivated; // da duoc unlock hay chua
    public int maxAmmo;
    public int currentAmmo;
    public float force;
    public float damage;
    public float range;
    public AudioClip shotAudio;
    public AudioClip emptyAudio;
}

public class WeaponSwitching : MonoBehaviour
{
    public List<GunData> allweapon;
    public int selectedWeapon = 0;
    public AudioSource switchingSound;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            // tim vu khu tiep theo dc unlock
            for (int i = selectedWeapon + 1; i < allweapon.Count; i++)
            {
                if (allweapon[i].isActivated)
                {
                    selectedWeapon = i;
                    switchingSound.Play();
                    break;
                }
            }
           
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            // tim vu khu tiep theo dc unlock
            for (int i = selectedWeapon - 1; i >= 0; i--)
            {
                if (allweapon[i].isActivated)
                {
                    selectedWeapon = i;
                    break;
                }
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }

    }

    public void UnlockWeapon(int weaponId)
    {
        for (int i = 0; i < allweapon.Count; i++)
        {
            if (allweapon[i].weaponId == weaponId)
            {
                if (allweapon[i].isActivated)
                {
                    allweapon[i].currentAmmo = allweapon[i].maxAmmo;
                }
                allweapon[i].isActivated = true;
            }
        }
        selectedWeapon = weaponId;// thay doi sang vu khi hien tai luon
        selectWeapon();
    }

    void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.GetComponent<Gun>().SetGunData(allweapon[selectedWeapon]);
                weapon.gameObject.SetActive(true);
                // play sound switch
                switchingSound.Play();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
