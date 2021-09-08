using System.Collections;
using System.Collections.Generic;
using Orakeshi.ApocalypseZ.Game.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace Orakeshi.ApocalypseZ.Game.UI
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
            foreach (Sprite sprite in gunLogos)
            {
                if (sprite.name == currentWeapon.transform.name)
                {
                    tempSprite = sprite;
                    gunLogo.GetComponent<Image>().sprite = tempSprite;
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
            if (currentWeapon == null)
            {
                foundWeapon = false;
                gunLogo.SetActive(false);
            }

            if (foundWeapon && currentWeapon)
            {
                Gun currentGun = currentWeapon.GetComponent<Gun>();
                if (currentGun.magazine)
                {
                    UpdateAmmoRemaining(currentGun.magazine.NumberOfBullets);
                }
            }
        }
    }
}

