using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Orakeshi.ApocalypseZ.Weapon;

namespace Orakeshi.ApocalypseZ.UI
{
    public class PlayerUI : MonoBehaviour, IChangeUI
    {
        public GameObject gunLogo;
        public GameObject baseHealth;
        public GameObject ammoCount;

        public List<Sprite> gunLogos = new List<Sprite>();

        private GameObject imgWeapon;
        private Sprite tempSprite;

        private bool foundWeapon = false;
        private GameObject currentWeapon;
        // Change gun logo, name, ammo count, ammo type, baseHealth

        public void ChangeUIItem()
        {
            
        }

        private void UpdateGunImage()
        {
            gunLogo.SetActive(true);
            GameObject weapon = GameObject.FindWithTag("Gun");

            foreach (var sprite in gunLogos)
            {
                if (sprite.name == weapon.name)
                {
                    tempSprite = sprite;
                    gunLogo.GetComponent<Image>().sprite = tempSprite;
                }
                else
                {
                    return;
                }
            }
        }

        private void UpdateAmmoRemaining(int ammoRemaining)
        {
            ammoCount.GetComponent<Text>().text = ammoRemaining.ToString();
        }

        private void Update()
        {
            if (!foundWeapon)
            {
                if (GameObject.FindWithTag("Gun") != null)
                {
                    foundWeapon = true;
                    currentWeapon = GameObject.FindWithTag("Gun");
                    UpdateGunImage();

                }
                else
                {
                    foundWeapon = false;
                    gunLogo.SetActive(false);
                }
            }
            if (currentWeapon)
            {
                Gun currentGun = currentWeapon.GetComponent<Gun>();
                if (currentGun.magazine)
                {
                    UpdateAmmoRemaining(currentGun.magazine.numberOfBullet);
                }
            }

        }
    }
}

