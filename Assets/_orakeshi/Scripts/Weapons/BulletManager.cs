using Orakeshi.ApocalypseZ.Zombie;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Weapon
{
    public class BulletManager : MonoBehaviour
    {
        public GameObject[] bulletFX;
        public int bulletDamage;
        private void OnCollisionEnter(Collision other)
        {
            
            if (other.gameObject.tag == "Tree")
            {
                foreach(var FX in bulletFX)
                {
                    if (FX.name.Contains("Wood"))
                    {
                        Instantiate(FX);
                        FX.transform.position = other.GetContact(0).point;
                        Destroy(this.gameObject);
                        //Destroy(FX, 3);
                    }
                }

            }
            else if (other.gameObject.tag == "Zombie")
            {
                ZombieEnemy zombie = other.transform.GetComponent<ZombieEnemy>();
                print("Hit Zom");
                zombie.TakeDamage(bulletDamage);
                zombie.damaged = true;
            }

            // If blood effect in scene - Play on impact when colliding with zombie

            else
            {
                Instantiate(bulletFX[0]);
                bulletFX[0].transform.position = other.GetContact(0).point;
                Destroy(this.gameObject);
                //Destroy(bulletFX[0], 1);

            }

        }
    }
}

