using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponSelectUI : MonoBehaviour
{
    public GameObject[] weapons;
    public Button[] UIButtons;
    public GameObject weaponSpawn;

    private List<GameObject> weaponsSpawned = new List<GameObject>();
    void Start()
    {
        foreach (var button in UIButtons)
        {
            button.onClick.AddListener(()=>
            {
                SpawnValidation(button.name);
            });
        }
    }

    void SpawnValidation(string gunName)
    {
        
        if (weaponsSpawned.Count >= 1)
        {
            Destroy(weaponsSpawned[0]);
            weaponsSpawned.Clear();
        }
        SpawnWeapon(gunName);
    }

    void SpawnWeapon(string gunName)
    {
        foreach(var weapon in weapons)
        {
            if(weapon.name == gunName)
            {
                GameObject temp = Instantiate(weapon);
                temp.transform.position = new Vector3(0.2920005f, 1.727f, 0.462f);
                weaponsSpawned.Add(temp);
            }
            else
            {
                print("no weapon found");
            }
        }
        //if(UIButtons.o)
        //if(gameObject.pres)
    }


    // Update is called once per frame
    void Update()
    {

    }
}
