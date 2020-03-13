using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CRI.HitBoxTemplate.Polar;
using System.Globalization;

namespace CRI.HitBoxTemplate.Example
{
	public class DataSaver : MonoBehaviour
	{

		private static DataSaver _instance;
		public static DataSaver Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Data Saver is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		public bool canSave = false;
		private PolarReceiver _polar;
		private Player_Movement_Follower _pmf;
		private MovingBar _mb;

		private void Start()
		{
			_polar = GameObject.Find("Polar").GetComponent<PolarReceiver>();
			_pmf = GameObject.Find("PlayerTracker").GetComponent<Player_Movement_Follower>();
			_mb = GameObject.Find("MovingBar").GetComponent<MovingBar>();
		}

		// Update is called once per frame
		void Update()
		{
			if (canSave)
			{
				if (_mb.reactionTime != 0f)
				{
					DataStorage.AppendToReport(
								new string[3] {
									_polar.bpm.ToString(),
									(_pmf._angle - _mb.currentAngle).ToString(CultureInfo.InvariantCulture),
									_mb.reactionTime.ToString(CultureInfo.InvariantCulture)
								}
							);
					_mb.reactionTime = 0f;
				}
				else
				{
					DataStorage.AppendToReport(
								new string[2] {
									_polar.bpm.ToString(),
									(_pmf._angle - _mb.currentAngle).ToString(CultureInfo.InvariantCulture)
								}
							);
				}
				canSave = false;
			}
		}
	}
}
