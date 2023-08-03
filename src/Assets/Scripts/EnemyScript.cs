using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField][Tooltip("�Ώە�(�v���C���[)")] private GameObject player = default!;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�Ɍ������Ĉړ�
        const float speed = 1.7f;
        Vector3 d = player.transform.position - this.transform.position;
        d.y = 0;
        Quaternion quaternion = Quaternion.LookRotation(d);
        this.transform.rotation = quaternion;

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
