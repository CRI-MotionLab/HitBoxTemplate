using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovingBar : MonoBehaviour
{
	public bool activated;
	public float side;
	private Vector3 _pos;
	private Vector3 _scale;

	void FixedUpdate()
	{
		_pos = transform.position;
		_scale = transform.localScale;
		if (activated == true && _scale.x != 13)
		{
			_scale.x += .125f;
			transform.localScale = _scale;
			_pos.x += side / 4;
			transform.position = _pos;
		}
		else if (activated == false && _scale.x != 3)
		{
			_scale.x -= .125f;
			transform.localScale = _scale;
			_pos.x -= side / 4;
			transform.position = _pos;
		}
	}
}
