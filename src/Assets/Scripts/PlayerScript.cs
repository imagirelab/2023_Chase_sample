using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    const float speed = 2.0f;
    [SerializeField] private EnemyDirector enemyDirector = default!;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
            dz += 1f;
        if (Input.GetKey(KeyCode.A))
            dx -= 1f;
        if (Input.GetKey(KeyCode.S))
            dz -= 1f;
        if (Input.GetKey(KeyCode.D))
            dx += 1f;

        float linv = 1.0f / Mathf.Sqrt(dx*dx+dz*dz+0.000001f);

        dx *= linv * Time.deltaTime * speed;
        dz *= linv * Time.deltaTime * speed;
        transform.position = new Vector3(
            transform.position.x + dx, transform.position.y, transform.position.z + dz
        );

        if (transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Goal":
                SceneManager.LoadScene("ClearScene");
                break;
            case "Enemy":
                SceneManager.LoadScene("GameOverScene");
                break;
            case "RedFloor":
                enemyDirector.changeMoveEnemy(EnemyDirector.ENEMY_TYPE.RED);
                break;
            case "GreenFloor":
                enemyDirector.changeMoveEnemy(EnemyDirector.ENEMY_TYPE.GREEN);
                break;
            case "BlueFloor":
                enemyDirector.changeMoveEnemy(EnemyDirector.ENEMY_TYPE.BLUE);
                break;
            case "Floor":
                break;
        }
    }
}
