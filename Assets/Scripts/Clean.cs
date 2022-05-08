using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean: MonoBehaviour {

	[SerializeField]
	private float destroyAfter = 2.0f;
	public bool _bPartOfPool = false; 
	private Vector3 _posInicial; 

	private void Start()
	{
		if (_bPartOfPool )
		{
			_posInicial = transform.position;
			StartCoroutine(returnPositionOriginal(destroyAfter));
		}
		else
		{
			Destroy(gameObject, destroyAfter);
		}
	}

	public void DestroyObject(){
		if (_bPartOfPool && destroyAfter > 0)
		{
			gameObject.transform.position = _posInicial;
            gameObject.SetActive(false);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	IEnumerator returnPositionOriginal(float pTimeWait)
    {
        yield return new WaitForSeconds(pTimeWait);
        gameObject.transform.position = _posInicial;
		gameObject.SetActive(false);
    }

}
