using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents current;

        private void Awake()
        {
            current = this;
        }

        public event Action<int> ONZombieTriggerSpawn;

        public void ZombieTriggerSpawn(int id)
        {
            ONZombieTriggerSpawn?.Invoke(id);
        }

        public event Action<int> ONZombieTriggerDeath;
        public void ZombieTriggerDeath(int id)
        {
            ONZombieTriggerDeath?.Invoke(id);
        }
    }
}
