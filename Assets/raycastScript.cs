using UnityEngine;
using System.Collections;

public class raycastScript : MonoBehaviour {
	RaycastHit hit;
	private Vector3 crosshairPosition;

	// Use this for initialization
	void Start () {
	class PostJsonDataScript : MonoBehaviour

			// Use this for initialization
			string Url;
			Start()
			{
				Url = "https://api.postmates.com//v1/customers/:cus_Kh6lCwLOnCLaG-/delivery_quotes ";
				PostData("2a3fbcc1-c142-4ae5-80a1-62e4343a170f");
			}
			// Update is called once per frame
			Update()
			{

			}
			void PostData(string apiK)
			{
				WWWForm dataParameters = new WWWForm();
				dataParameters.AddField("username", apiK);
				dataParameters.AddField("password", "");
				dataParameters.AddField("dropoff_address","1201 E California Blvd California Institute of Technology Pasadena, CA 91106");
				dataParameters.AddField("pickup_address","171 N Holliston Ave, Pasadena, CA 91106");
				WWW www = new WWW(Url,dataParameters);
				StartCoroutine("PostdataEnumerator", Url);
			}
			IEnumerator PostdataEnumerator(WWW www)
			{
				yield return www;
				if (www.error != null)
				{
					Debug.Log("Data Submitted");
				}
				else
				{
					Debug.Log(www.error);
				}
			}
		}
		
	
	// Update is called once per frame
	void Update () {

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 100)) {
			if (hit.collider.name == "MagicLamp") {
				Debug.Log ("You ordered food!");
			}
		}

		Debug.DrawRay (transform.position, fwd, Color.blue);

	}
}
