using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace Orakeshi.ApocalypseZ.Game.UI
{
    public class WeaponSelectUI : MonoBehaviour, ISelectable
    {
        public GameObject[] weapons;
        public Button[] uiButtons;
        public GameObject weaponSpawn;

        private readonly List<GameObject> weaponsSpawned = new List<GameObject>();

        private void Start()
        {
            foreach (var button in uiButtons)
            {
                button.onClick.AddListener(() =>
                {
                    SpawnValidation(button.name);
                });
            }
        }

        private void SpawnValidation(string gunName)
        {

            if (weaponsSpawned.Count >= 1)
            {
                Destroy(weaponsSpawned[0]);
                weaponsSpawned.Clear();
            }
            InstantiateItem(gunName);
        }

        public void InstantiateItem(string gunName)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.name == gunName)
                {
                    GameObject temp = Instantiate(weapon);
                    temp.transform.position = new Vector3(0.2920005f, 1.727f, 0.462f);
                    temp.name = weapon.name;
                    weaponsSpawned.Add(temp);
                }
                else
                {
                    print("no weapon found");
                }
            }
        }
    }
}

