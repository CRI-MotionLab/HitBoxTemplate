using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hitbox.PingPong2X
{
    public class TargetBehavior : MonoBehaviour
    {
        private int _index = 0;
        private bool _state = false;

        private Renderer _render;
        [SerializeField]
        private Color _activeColor = Color.red;
        [SerializeField]
        private Color _inactiveColor = Color.blue;
        

        [SerializeField]
        private GameObject _hitFeedbackPrefab;

        void Awake()
        {
            _render = GetComponent<Renderer>();
        }

        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        public void SetHit()
        {
			// Trigger explose animation = instantiate impact explosion
            if (_hitFeedbackPrefab != null)
            {
                var go = Instantiate(_hitFeedbackPrefab, this.transform.position, Quaternion.identity);
                go.gameObject.layer = this.gameObject.layer;
            }
            State = !State;
        }

		private void Update()
		{
			if (_state)
			{
				_render.material.SetColor("_Color", _activeColor);
			}
			else
			{
				_render.material.SetColor("_Color", _inactiveColor);
			}
		}

		void OnBecameInvisible()
        {
            this.destroyTarget();
        }

        public void destroyTarget()
        {
            Destroy(this.gameObject);
        }
    }
}
