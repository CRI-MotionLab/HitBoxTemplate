using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovingBar : MonoBehaviour
{
	public bool activated;
	public int side;
	private Vector3 _pos;
	private Vector3 _scale;

	private void Start()
	{
		_pos = transform.position;
		_scale = transform.localScale;
	}

	void Update()
	{
		if (activated == true && _scale.x != 53)
		{
			_scale.x += 1;
			transform.localScale = _scale;
			_pos.x += side / 2;
			transform.position = _pos;
		}
		else if (activated == false && _scale.x != 3)
		{
			_scale.x -= 1;
			transform.localScale = _scale;
			_pos.x -= side / 2;
			transform.position = _pos;
		}
	}
}
