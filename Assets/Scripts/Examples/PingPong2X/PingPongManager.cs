using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hitbox.PingPong2X
{
	[Serializable]
	public struct PlayerSettings {
		public GameObject hitbox;
		public Color color;

		public PlayerSettings(GameObject hitbox_, Color color_)
		{
			this.hitbox = hitbox_;
			this.color = color_;
		}
	}

	public class PingPongManager : MonoBehaviour
	{
		[SerializeField]
		private PlayerSettings[] _players = null;

		[SerializeField]
        private int _nTargets = 3;
		[SerializeField]
		private float _radius = 5f;

        // Start is called before the first frame update
        void Start()
        {
            if (_players != null)
			{
				for (int i = 0; i < _players.Length; i++)
				{
					_players[i].hitbox.GetComponent<ImpactManager>().PlayerIndex = i;
					_players[i].hitbox.GetComponent<TargetsManager>().SetCrownTargets(_nTargets, _radius, _players[i].color);
				}
			}
		}

        public void SetHit(int playerIndex_, int targetIndex_)
        {
			int nextPlayer_ = playerIndex_ + 1;
			if (nextPlayer_ >= _players.Length)
			{
				nextPlayer_ = 0;
			}

			int prevPlayer_ = playerIndex_ - 1;
			if (prevPlayer_ < 0)
			{
				prevPlayer_ = _players.Length - 1;
			}

			Debug.Log(prevPlayer_ + "[" + targetIndex_ + "] -- > " + playerIndex_ + "[" + targetIndex_ + "] -- > " + nextPlayer_ + "[" + targetIndex_ + "]");

			_players[playerIndex_].hitbox.GetComponent<TargetsManager>().SetTarget(targetIndex_, _players[prevPlayer_].color);
			_players[nextPlayer_].hitbox.GetComponent<TargetsManager>().SetTarget(targetIndex_, _players[playerIndex_].color);
		}

        // Update is called once per frame
        void Update()
        {

        }
    }
}