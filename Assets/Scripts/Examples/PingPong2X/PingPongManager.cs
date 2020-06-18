using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hitbox.PingPong2X
{
	public class PingPongManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _players;
		[SerializeField]
        private int _nTargets = 3;
		[SerializeField]
		private float _radius = 5f;
		private GameObject[,] _targets;

        // Start is called before the first frame update
        void Start()
        {
            _targets = new GameObject[_players.Length , _nTargets];

			if (_players != null)
			{
				for (int i = 0; i < _players.Length; i++)
				{
					_players[i].GetComponent<ImpactManager>().PlayerIndex = i;
					_players[i].GetComponent<TargetsManager>().SetCrownTargets(_nTargets, _radius);
				}
			}
		}

        public void SetHit(int playerIndex_, int targetIndex_)
        {
			int nextPlayer_ = playerIndex_++;
			if (nextPlayer_ >= _players.Length) { nextPlayer_ = 0; }
			_players[nextPlayer_].GetComponent<TargetsManager>().SetTarget(targetIndex_);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}