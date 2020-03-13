﻿using UnityEngine;
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using CRI.HitBoxTemplate.Example;

namespace CRI.HitBoxTemplate.Polar
{
	public class PolarReceiver : MonoBehaviour
	{
		// read Thread
		private Thread readThread;
		// udpclient object
		private UdpClient client;
		// port number
		public int port = 8088;
		// List holding received data
		public List<byte> polarData;
		// Last value received
		public byte bpm;

		void Start()
		{
			polarData = new List<byte>();
			// create thread for reading UDP messages
			readThread = new Thread(new ThreadStart(ReceiveData));
			readThread.IsBackground = true;
			readThread.Start();
		}

		// Unity Application Quit Function
		void OnApplicationQuit()
		{
			stopThread();
			polarData.Clear();
		}

		// Stop reading UDP messages
		private void stopThread()
		{
			if (readThread.IsAlive)
			{
				readThread.Abort();
			}
			client.Close();
		}

		// Storing data in list of 30 elements maximum
		private void StoreData(byte data)
		{
			if (polarData.Count < 29)
				polarData.Add(data);
			else
			{
				polarData.RemoveAt(0);
				polarData.Add(data);
			}
		}

		// Receive thread function
		private void ReceiveData()
		{
			client = new UdpClient(port);
			client.Client.ReceiveTimeout = 1000;
			while (true)
			{
				try
				{
					// Receive bytes
					IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
					byte[] data = client.Receive(ref anyIP);
					DataSaver.Instance.canSave = true;
					StoreData(data[1]);
					bpm = data[1];
				}
				catch (Exception err)
				{
					print(err.ToString());
				}
			}
		}
	}
}