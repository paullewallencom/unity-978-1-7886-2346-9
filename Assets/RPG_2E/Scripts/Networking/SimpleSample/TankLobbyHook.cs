using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class TankLobbyHook : LobbyHook
{
	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		MyPlayerController tank = gamePlayer.GetComponent<MyPlayerController>();

		tank.myColor = lobby.playerColor;
		//spaceship.name = lobby.name;
		//spaceship.color = lobby.playerColor;
		//spaceship.score = 0;
		//spaceship.lifeCount = 3;
	}
}
