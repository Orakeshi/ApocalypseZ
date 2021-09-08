using System;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Weapon
{
    public class Magazine : MonoBehaviour
    {
        [SerializeField]
        private int numberOfBullets = 9000000;

        public int NumberOfBullets
        {
            get => numberOfBullets;

            set => numberOfBullets = value;
        }
    }
}

