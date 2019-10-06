using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    private float cdAttack = 3f;


    public enum States
    {
        MOVIMENT,
        PREATTACK,
        ATTACK,
        UPGRADE,
        DEATH
    };

    private States currentState = States.MOVIMENT;
    delegate void State();
    Dictionary<States, State> statesList = new Dictionary<States, State>();

    void Start()
    {
        currentState = States.MOVIMENT;

        statesList.Add(States.MOVIMENT, MovimentState);
        statesList.Add(States.PREATTACK, PreAttackState);
        statesList.Add(States.ATTACK, AttackState);
        statesList.Add(States.UPGRADE, UpgradeState);
        statesList.Add(States.DEATH, DeathState);

        life = 10;
        exp = 0;
        damage = 2;
        critical = 0;
        level = 1;
    }    

    void Update()
    {
        Debug.Log(currentState);

        if (life <= 0)
        {
            currentState = States.DEATH;
        }

        if (statesList.ContainsKey(currentState))
        {
            statesList[currentState]();
        }            
    }

    private void MovimentState()
    {
        Ray ray = new Ray(transform.position + Vector3.right, Vector3.right);        
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 13f);
       // Debug.DrawRay(ray.origin, ray.direction * 13f, Color.black);
       // Debug.Log(hit.transform.tag);

        if (hit.transform && hit.transform.CompareTag("Enemy"))
        {
            currentState = States.PREATTACK;
        }
    }

    private void AttackState()
    {
        currentState = States.PREATTACK;
        cdAttack = 3f;
    }

    private void PreAttackState()
    {
        Ray ray = new Ray(transform.position + Vector3.right, Vector3.right);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 13f);


        cdAttack -= 1 * Time.deltaTime;

        if (hit.transform && hit.transform.CompareTag("Enemy"))
        {
            if (cdAttack <= 0)
            {
                currentState = States.ATTACK;
            }
        }
        else
        {
            currentState = States.MOVIMENT;
        }
    }

    private void UpgradeState()
    {
        throw new NotImplementedException();
    }

    private void DeathState()
    {
        throw new NotImplementedException();
    }

    //TODO: A METHOD TO CHECK THE CURRENT STATES TO USE WITH ANIMATION
}
