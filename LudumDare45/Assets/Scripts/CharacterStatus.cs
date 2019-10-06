using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // GENERIC STATUS
    protected float level;
    protected float exp;
    protected float life;
    protected float damage;
    protected float critical;

    // COMBAT TOOLS
    protected float cooldownPower;

    protected void IncrementeLife(float value)
    {
        life += value;
    }

    protected void IncrementeDamage(float value)
    {
        damage += value;
    }

    protected void IncrementeCritical(float value)
    {
        critical += value;
    }

}
