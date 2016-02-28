using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

namespace muse_osc_server
{
	public class OSCReader : MonoBehaviour {
		public GameObject cube;
		public GameObject mellowObject;
		public GameObject concentratedObject;
		public GameObject Sky;
		private float mellow;
		private float concentration;

		// Use this for initialization
		void Start () {
			// Callback function for received OSC messages. 
			// Prints EEG and Relative Alpha data only.
			HandleOscPacket callback = delegate(OscPacket packet)
			{
				var messageReceived = (OscMessage)packet;
				var addr = messageReceived.Address;

				// RAW EEG
				if(addr == "/muse/eeg") {
					//Debug.Log("EEG values: ");
					foreach(var arg in messageReceived.Arguments) {
						//Debug.Log(arg + " ");
					}
				}

				// ALPHA
				if(addr == "/muse/elements/alpha_relative") {
					//Debug.Log("Relative Alpha power values: ");
					foreach(var arg in messageReceived.Arguments) {
						//Debug.Log("alpha: " + arg + " ");
					}
				}

				// GAMMA
				if(addr == "/muse/elements/gamma_relative") {
					//Debug.Log("Relative Gamma power values: ");
					foreach(var arg in messageReceived.Arguments) {
						//Debug.Log("gamma: " + arg + " ");
					}
				}

				// CONCENTRATION
				if(addr == "/muse/elements/experimental/concentration") {
					//Debug.Log("Concentration: ");
					foreach(var arg in messageReceived.Arguments) {
						//Debug.Log("concentration " + arg + " ");
						concentration = (float)arg;


					}
				}

				// MELLOW
				if(addr == "/muse/elements/experimental/mellow") {
					//Debug.Log("Mellow: ");
					foreach(var arg in messageReceived.Arguments) {
						//Debug.Log("mellow" + arg + " ");
						mellow = (float)arg;
					}
				}


				Debug.Log("(0," + concentration + "," + mellow + "," + 1 +")");
			};


			// Create an OSC server.
			var listener = new UDPListener(5000, callback);
		}
		
		// Update is called once per frame
		void Update () {

			Color planeColor = new Color(1-mellow, concentration, mellow, 1);

			cube.GetComponent<Renderer>().material.color = planeColor;


			Color mellowColor = new Color(1-mellow, 0, mellow, 1);

			mellowObject.GetComponent<Renderer>().material.color = mellowColor;


			Color concentrationColor = new Color(1-concentration, 0, concentration, 1);

			concentratedObject.GetComponent<Renderer>().material.color = concentrationColor;


			Color skyColor = new Color(1, concentration, concentration, 1);

			Sky.GetComponent<Renderer>().material.color = skyColor;

		
		}
	}
}