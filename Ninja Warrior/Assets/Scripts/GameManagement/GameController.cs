using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (MinerStatus.hp <= 0)
            PlayerDash.hasDashPower = true;
            

        if (Dragon.hp <= 0)
            PlayerShoot.hasFirePower = true;
    }
}