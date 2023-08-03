using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine("WaitAndNext");
        }
    }
    IEnumerator WaitAndNext()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("PlayScene");
    }
}
