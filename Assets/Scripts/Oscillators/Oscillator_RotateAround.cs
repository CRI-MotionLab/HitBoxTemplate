using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_RotateAround : MonoBehaviour
{
	[SerializeField]
	private GameObject _target;
	[SerializeField]
	private float _speed = 5f;

	void Update()
	{
		Vector3 rotCenter_ = Vector3.zero;
		if (_target != null)
		{
			rotCenter_ = _target.transform.position;
		}
		transform.RotateAround(rotCenter_, this.transform.up, _speed * Time.deltaTime);
	}
}
