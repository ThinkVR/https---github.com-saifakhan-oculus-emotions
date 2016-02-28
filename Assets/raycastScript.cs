using UnityEngine;
using System.Collections;

public class raycastScript : MonoBehaviour {
	RaycastHit hit;
	private Vector3 crosshairPosition;
	public string Url;

	// Use this for initialization
	void Start () {
		Url = "https://dc4fcee9-a480-4a90-bdcb-604c6a94bf62:@api.postmates.com/v1/customers/cus_Kh57GI1WZmMazk/delivery_quotes ";
		PostData("dc4fcee9-a480-4a90-bdcb-604c6a94bf62");
		// Use this for initialization
		Debug.Log(Url);

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

	void PostData(string apiK)
	{
		WWWForm dataParameters = new WWWForm();
		// var headers = new Hashtable ();
		// headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(apiK+":"));
//		dataParameters.AddField("username", apiK);
//		dataParameters.AddField("password", "");
		dataParameters.AddField("dropoff_address","20 McAllister St, San Francisco, CA");
		dataParameters.AddField("pickup_address","101 Market St, San Francisco, CA");
		WWW www = new WWW(Url ,dataParameters);
		StartCoroutine(PostdataEnumerator(www));
	}

	IEnumerator PostdataEnumerator(WWW www)
	{
		yield return www;
		if (www.error != null)
		{
			Debug.Log (www.text);
			Debug.Log("Data Submitted");
		}
		else
		{
			Debug.Log(www.text);
		}
	}
}
