using UnityEngine;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

namespace com.noorcon.rpg2e
{
	public class PlayerCharacterLobbyHook : LobbyHook
	{
		public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
		{
			LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
			BarbarianCharacterNetworkController playerController = gamePlayer.GetComponent<BarbarianCharacterNetworkController>();

			playerController.name = lobby.playerName;

			//GameMasterNetwork.instance.PlayerCharacterData
			//	= gamePlayer.GetComponent<PlayerAgent>().playerCharacterData;

			GameMasterNetwork.instance.PlayerCharacterGameObject
				= gamePlayer;

			//spaceship.color = lobby.playerColor;
			//spaceship.score = 0;
			//spaceship.lifeCount = 3;
		}
	}
}