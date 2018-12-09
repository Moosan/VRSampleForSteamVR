//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Handles rendering to the game view window
//
//=============================================================================

using UnityEngine;

[ExecuteInEditMode]
public class SteamVR_GameView : MonoBehaviour
{
	void Awake()
	{
		Debug.Log("SteamVR_GameView is deprecated in Unity 5.4 - REMOVING");
        Debug.Log("SteamVR_GameViewというクラスは、このバージョンのUnityでは非推奨なため、削除されました。");
		DestroyImmediate(this);
	}
}

