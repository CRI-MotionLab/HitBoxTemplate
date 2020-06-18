using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_Ellipse : MonoBehaviour
{
	private float _time = 0;
	[SerializeField]
	private float _speed = 5;
	[SerializeField]
	private float _radiusX = 2;
	[SerializeField]
	private float _radiusY = 1;

	private bool _isRotate = false;

	Vector3 _position0;

	// Start is called before the first frame update
	void Start()
	{
		_position0 = this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonUp(0))
		{
			_isRotate = !_isRotate;
			_position0 = this.transform.position;
		}

		if (_isRotate)
		{
			_time += Time.deltaTime * _speed;

			float x_ = Mathf.Cos(_time) * _radiusX;
			float y_ = Mathf.Sin(_time) * _radiusY;
			float z_ = 0;

			transform.position = new Vector3(x_, y_, z_) + _position0;
		}
	}
}
