using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public interface IEnemy
    {
        int health { set; }
        int attackDamage { set; }
    }
}
