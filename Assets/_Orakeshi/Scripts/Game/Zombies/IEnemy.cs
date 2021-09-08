using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    public interface IEnemy
    {
        int Health { set; }
        int AttackDamage { set; }
    }
}
