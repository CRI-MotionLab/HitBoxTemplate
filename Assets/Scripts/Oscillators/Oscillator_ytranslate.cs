using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_ytranslate : MonoBehaviour
{
	private float _time = 0;
	[SerializeField]
	private float _speed = 5;
	[SerializeField]
	private float _rangeY = 2;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		_time += Time.deltaTime * _speed;
		float y_ = Mathf.Cos(_time) * _rangeY;
		transform.position = transform.parent.position + new Vector3(0, y_, 0);
	}
}
