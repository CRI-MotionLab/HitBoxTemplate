using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_Rotate : MonoBehaviour
{
	[SerializeField]
	private float _speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(new Vector3(0, _speed, 0), Space.Self);
	}
}
