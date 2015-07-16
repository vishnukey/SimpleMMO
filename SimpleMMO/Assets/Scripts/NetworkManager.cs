using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{

	private const string typeName = "PFaj_SimpleMMO";
	private const string gameName = "RoomName";
	
	private void StartServer ()
	{
		Network.InitializeServer (5, 2500, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (typeName, gameName);
	}
	
	public void PublicStartServer ()
	{
		if (!(Network.isClient || Network.isServer)) {
			StartServer ();
		}
	}
	
	void OnServerInitialized ()
	{
		Debug.Log ("server started");
	}
	
	void OnGUI ()
	{
		Debug.Log ("gui");
		if (!(Network.isClient || Network.isServer)) {
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server")) {
				StartServer ();
			}
		}
	}

	private HostData[] hostList;
	
	private void RefreshHostList ()
	{
		MasterServer.RequestHostList (typeName);
	}
	
	void OnMasterServerEvent (MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList ();
		}
	}
}
