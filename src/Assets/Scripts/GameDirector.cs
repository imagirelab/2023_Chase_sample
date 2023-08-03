using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    bool pause = true;
    [SerializeField] private EnemyDirector _enemyDirector = default!;
    [SerializeField] private PlayerScript _playerScript = default!;

    // Start is called before the first frame update
    void Start()
    {
        Pause(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        Pause(false);
    }

    public void Pause(bool pa)
    {
        pause = pa;

        _enemyDirector.Pause(pause);
        _playerScript.enabled = !pause;
    }
}
