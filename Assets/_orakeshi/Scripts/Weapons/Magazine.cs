using System;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Weapon
{
    public class Magazine : MonoBehaviour
    {
        [SerializeField]
        private int numberOfBullets = 900000000;

        public int NumberOfBullets
        {
            get
            {
                return numberOfBullets;
            }

            set
            {
                numberOfBullets = value;
            }
        }
    }
}

