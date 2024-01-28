using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio/Audio")]
public class Audio : ScriptableObject

{
	//Player
	public EventReference playerRun;
	public EventReference playerJump;
	public EventReference playerDoubleJump;
	//public EventReference playerVoice;
	public EventReference playerSpriteFlip;
	public EventReference playerHurt;

	// Weapon
	public EventReference punchlineAppear;
	public EventReference punchlinePunch;
	public EventReference punchlineDrop;

	//Enemy & objects
	//public EventReference enemyRun;
	//public EventReference enemyVoice;
	public EventReference enemyDeath;
	public EventReference wallSmash;
	public EventReference bounce;
	public EventReference monster;

	//UI
	//public EventReference onMouseOver;
	//public EventReference onMouseClick;

	//Music
	public EventReference mainMusic;
	private EventInstance mainMusicInstance;

	//PLAYER FUNCTIONS
	public void PlayPlayerRun(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerRun, gameObject);
	}

	public void PlayPlayerJump(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerJump, gameObject);
	}

	public void PlayPlayerDoubleJump(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerDoubleJump, gameObject);
	}

	/*public void PlayPlayerVoice(GameObject gameObject)
    {
        RuntimeManager.PlayOneShotAttached(playerVoice, gameObject);
    }*/

	public void PlayPlayerSpriteFlip(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerSpriteFlip, gameObject);
	}
	
	public void PlayPlayerHurt(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerHurt, gameObject);
	}

	//WEAPON FUNCTIONS
	public void PlayPunchlineAppear(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(punchlineAppear, gameObject);
	}

	public void PlayPunchlinePunch(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(punchlinePunch, gameObject);
	}

	public void PlayPunchlineDrop(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(punchlineDrop, gameObject);
	}

	//ENEMY & OBJECT FUNCTIONS 
	/*public void PlayEnemyRun(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(enemyRun, gameObject);
	}*/

	/*public void PlayEnemyVoice(GameObject gameObject)
    {
        RuntimeManager.PlayOneShotAttached(enemyVoice, gameObject);
    }*/

	public void PlayEnemyDeath(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(enemyDeath, gameObject);
	}
	public void PlayPlayerDeath(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(playerHurt, gameObject);
	}
	
	public void PlayWallSmash(GameObject gameObject)
    	{
    		RuntimeManager.PlayOneShotAttached(wallSmash, gameObject);
    	}
	
	public void PlayBounce(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(bounce, gameObject);
	}
	
	public void PlayMonster(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(monster, gameObject);
	} 

	//UI FUNCTIONS
	/*public void PlayOnMouseOver(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(onMouseOver, gameObject);
	}

	public void PlayOnMouseClick(GameObject gameObject)
	{
		RuntimeManager.PlayOneShotAttached(onMouseClick, gameObject);
	}*/


	//MUSIC FUNCTIONS
	public void StartMusic(GameObject gameObject)
	{
		mainMusicInstance = RuntimeManager.CreateInstance(mainMusic);
		RuntimeManager.AttachInstanceToGameObject(mainMusicInstance, gameObject.transform);

		mainMusicInstance.start();
	}

	public void StopMusic(GameObject gameObject)
	{
		mainMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
		mainMusicInstance.release();
	}
}
