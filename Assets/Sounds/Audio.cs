using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using FMOD.Studio;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio/Audio")]
public class Audio : ScriptableObject

{
    //Player
    public EventReference playerRun;
    public EventReference playerJump;
    public EventReference playerDoubleJump;
    public EventReference playerVoice;
    public EventReference playerSpriteFlip;
   
    // Weapon
    public EventReference punchlineAppear;
    public EventReference punchlinePunch;
    
    //Enemy
    public EventReference enemyRun;
    public EventReference enemyVoice;
    public EventReference enemyDeath;

    //UI
    public EventReference onMouseOver;
    public EventReference onMouseClick;
    
    //Music
    public EventReference mainMusic;
    private EventInstance mainMusicInstance;

    
    //PLAYER FUNCTIONS
    public void PlayPlayerRun()
    {
        
    }

    public void PlayPlayerJump()
    {
        
    }

    public void PlayPlayerDoubleJump()
    {
        
    }

    public void PlayPlayerVoice()
    {
        
    }

    public void PlayPlayerSpriteFlip()
    {
        
    }
    
    //WEAPON FUNCTIONS
    public void PlayPunchlineAppear()
    {
        
    }

    public void PlayPunchlinePunch()
    {
        
    }
    
    //ENEMY FUNCTIONS
    public void PlayEnemyRun()
    {
        
    }

    public void PlayEnemyVoice()
    {
        
    }

    public void PlayEnemyDeath()
    {
        
    }
    
    //UI FUNCTIONS
    public void PlayOnMouseOver()
    {
        
    }

    public void PlayOnMouseclick()
    {
        
    }

    
    //MUSIC FUNCTIONS
    public void StartMusic()
    {
        
    }

    public void StopMusic()
    {
        
    }
}
