using UnityEngine;
using CRI.HitBoxTemplate.Serial;

namespace CRI.HitBoxTemplate.Example
{
	public class MovingBar : MonoBehaviour
	{
		[SerializeField]
		private GameObject _bar;
		[SerializeField]
		private Material _red;
		[SerializeField]
		private Material _blue;
		[SerializeField]
		private float _speed = .5f;
		[SerializeField]
		private float _maxAngle = 45f;
		public float currentAngle = 0f;
		private int _direction = 1;
		private float _timeKeeper = 0f;
		private float _timeSinceStrike = 0f;
		public float reactionTime = 0f;
		private bool _lineMoving = true;
		private bool _strikeTime = true;
		private bool _started = false;
		public int round = 0;

		private void OnEnable()
		{
			ImpactPointControl.onImpact += OnImpact;
		}

		private void OnDisable()
		{
			ImpactPointControl.onImpact -= OnImpact;
		}

		private void OnImpact(object sender, ImpactPointControlEventArgs e)
		{
			if (!_strikeTime || Time.realtimeSinceStartup < 2f) // waiting for the startup ghost hits to finish before registering any hit
				return;
			if (!_started)
			{
				_started = true;
				round++;
				DataSaver.Instance.Separator("Round Start");
				return;
			}
			if (Random.Range(0, 2) == 0)
				_direction = -_direction;
			_lineMoving = true;
			_bar.GetComponent<MeshRenderer>().material = _blue;
			_strikeTime = false;
			reactionTime = _timeSinceStrike;
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			currentAngle = (transform.position.x) * 3.6f;
			if (!_started)
				return;
			_timeKeeper += Time.fixedDeltaTime;
			_timeSinceStrike += Time.fixedDeltaTime;
			if (_timeKeeper >= 180.0f)
			{
				_started = false;
				_timeKeeper = 0f;
				_timeSinceStrike = 0f;
				DataSaver.Instance.Separator("Round Over");
				return;
			}
			else if (_timeSinceStrike >= 3f)
			{
				_bar.GetComponent<MeshRenderer>().material = _red;
				_lineMoving = false;
				_timeSinceStrike = 0f;
				_strikeTime = true;
			}
			else if (_lineMoving)
			{
				float _xMax = 100f / 360f * _maxAngle;
				if (transform.position.x > _xMax || transform.position.x < -_xMax)
					_direction = -_direction;
				transform.Translate(_speed * _direction, 0, 0);
			}
		}
	}
}
