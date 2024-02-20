using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void SetParameters(WeaponData weaponData, int attackPower, float inactiveDelay, WeaponSpawner.Direction direction);


}
