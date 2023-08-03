using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField][Tooltip("対象物(プレイヤー)")] private GameObject player = default!;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーに向かって移動
        const float speed = 1.7f;
        Vector3 d = player.transform.position - this.transform.position;
        d.y = 0;
        Quaternion quaternion = Quaternion.LookRotation(d);
        this.transform.rotation = quaternion;

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
