using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Weapon
{
    public class BulletManager : MonoBehaviour
    {
        public GameObject[] bulletFX;
        private void OnCollisionEnter(Collision other)
        {
            
            if (other.gameObject.tag == "Tree")
            {
                foreach(var FX in bulletFX)
                {
                    if (FX.name.Contains("Wood"))
                    {
                        Instantiate(FX);
                        FX.transform.position = gameObject.transform.position;
                        Destroy(this.gameObject);
                        Destroy(FX, 1);
                    }
                }

            }
            //else if (other.gameObject.tag == "Zombie")
            //{

            //}
            else
            {
                Instantiate(bulletFX[0]);
                bulletFX[0].transform.position = gameObject.transform.position;
                Destroy(this.gameObject);
                Destroy(bulletFX[0], 1);
                
            }
        }
    }
}

