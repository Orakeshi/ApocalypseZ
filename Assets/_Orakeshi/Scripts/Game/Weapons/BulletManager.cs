using System.Collections;
using System.Collections.Generic;
using Orakeshi.ApocalypseZ.Game.Zombies;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Weapon
{
    public class BulletManager : MonoBehaviour
    {
        public GameObject[] bulletFX;
        public int bulletDamage;
        private void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                case "Tree":
                {
                    foreach(var fx in bulletFX)
                    {
                        if (fx.name.Contains("Wood"))
                        {
                            Instantiate(fx);
                            fx.transform.position = other.GetContact(0).point;
                            Destroy(this.gameObject);
                            //Destroy(FX, 3);
                        }
                    }

                    break;
                }
                
                case "Zombie":
                {
                    ZombieEnemy zombie = other.transform.GetComponent<ZombieEnemy>();
                    print("Hit Zom");
                    zombie.TakeDamage(bulletDamage);
                    //zombie.damaged = true;
                    break;
                }
                // If blood effect in scene - Play on impact when colliding with zombie
                default:
                    Instantiate(bulletFX[0]);
                    bulletFX[0].transform.position = other.GetContact(0).point;
                    Destroy(this.gameObject);
                    //Destroy(bulletFX[0], 1);
                    break;
            }
        }
    }
}

