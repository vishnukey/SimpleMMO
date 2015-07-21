using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager 
{
	public List<GameObject> players;

	void Start ()
	{
		players = new List<GameObject>(); 
		InvokeRepeating("ChangeColours", 1, 2F);
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		players.Add(player);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	void ChangeColours()
	{
		foreach (GameObject player in players)
		{
			if (player == null)
			{
				players.Remove(player);
				continue;
			}
			player.GetComponent<Player>().colour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
	}
}
