using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus
{
    // GENERIC STATUS
    private float level;
    private float exp;
    private float life;
    private float damage;
    private float critical;

    // COMBAT TOOLS
    protected float cooldownPower;

    public float Life { get => life; set => life += value; }
    public float Damage { get => damage; set => damage += value; }
    public float Critical { get => critical; set => critical += value; }
    public float Level { get => level; set => level += value; }
    public float Exp { get => exp; set => exp += value; }
}
