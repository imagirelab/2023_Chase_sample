using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textCountdown = default!;
	[SerializeField]
	private GameDirector _gameDirector = default!;

	// Start is called before the first frame update
	void Start()
    {
        _textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator CountdownCoroutine()
	{
		_textCountdown.gameObject.SetActive(true);

		_textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "GO!";
		_gameDirector.Begin();
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
	}
}
