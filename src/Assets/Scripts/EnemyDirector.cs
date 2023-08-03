using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    [SerializeField] private GameObject parentRed = default!;
    [SerializeField] private GameObject parentGreen = default!;
    [SerializeField] private GameObject parentBlue = default!;

    public enum ENEMY_TYPE
    {
        RED,
        GREEN,
        BLUE,

        INVALID,
    }
    ENEMY_TYPE active = ENEMY_TYPE.BLUE;


    // Start is called before the first frame update
    void Start()
    {
//        changeMoveEnemy(ENEMY_TYPE.BLUE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMoveEnemy(ENEMY_TYPE type, bool force = false)
    {
        if (active == type && !force) return;
        active = type;

        switch(type)
        {
            case ENEMY_TYPE.RED:
                Enable2Move(parentRed);
                Disable2Move(parentGreen);
                Disable2Move(parentBlue);
                break;
            case ENEMY_TYPE.GREEN:
                Enable2Move(parentGreen);
                Disable2Move(parentBlue);
                Disable2Move(parentRed);
                break;
            case ENEMY_TYPE.BLUE:
                Enable2Move(parentBlue);
                Disable2Move(parentRed);
                Disable2Move(parentGreen);
                break;
        }
    }

    void Enable2Move(GameObject g)
    {
        EnemyScript[] Enemies = g.GetComponentsInChildren<EnemyScript>();

        foreach (EnemyScript e in Enemies)
        {
            e.enabled = true;
        }
    }

    void Disable2Move(GameObject g)
    {
        EnemyScript[] Enemies = g.GetComponentsInChildren<EnemyScript>();

        foreach (EnemyScript e in Enemies)
        {
            e.enabled = false;
        }
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Disable2Move(parentRed);
            Disable2Move(parentGreen);
            Disable2Move(parentBlue);
        }
        else
        {
            changeMoveEnemy(active, true);
        }

    }
}
