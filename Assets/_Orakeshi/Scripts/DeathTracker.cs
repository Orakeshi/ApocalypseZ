using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.App
{
    public class DeathTracker : MonoBehaviour
    {
        int totalZombieDeaths = 0;

        public int TotalZombieDeaths
        {
            get
            {
                return TotalZombieDeaths;
            }
            set
            {
                totalZombieDeaths = value;
            }
        }
    }
}


