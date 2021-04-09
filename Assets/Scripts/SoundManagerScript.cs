using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //All soundeffects that we need    
    public static AudioClip bgMusic,
        shootSound,
        hitCoronaSound,
        instPowerUpSound,
        levelUpSound,
        powerUpSound,
        loseLifeSound,
        playerDeathSound,
        nextLevelSound;

    private static AudioSource audioSrc;
    
    void Start()
    {
        bgMusic = Resources.Load<AudioClip>("Forest 6 - Ice Forest");
        shootSound = Resources.Load<AudioClip>("dub");
        hitCoronaSound = Resources.Load<AudioClip>("pumm");
        instPowerUpSound = Resources.Load<AudioClip>("huuuupium");
        levelUpSound = Resources.Load<AudioClip>("baling");
        powerUpSound = Resources.Load<AudioClip>("power up");
        loseLifeSound = Resources.Load<AudioClip>("wlum");
        playerDeathSound = Resources.Load<AudioClip>("sad");
        nextLevelSound = Resources.Load<AudioClip>("didudu");



        audioSrc = GetComponent<AudioSource>();
        
        PlaySound("bg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bg":
                audioSrc.PlayOneShot(bgMusic, 0.1f);
                
                break;
            case "shoot":
                audioSrc.PlayOneShot(shootSound, 0.3f);
                break;
            case "hitCorona":
                audioSrc.PlayOneShot(hitCoronaSound, 1f);
                break;
            case "InstantiatePowerUp":
                audioSrc.PlayOneShot(instPowerUpSound, 0.6f);
                break;
            case "levelUp":
                audioSrc.PlayOneShot(levelUpSound, 0.3f);
                break;
            case "powerUp":
                audioSrc.PlayOneShot(powerUpSound, 0.3f);
                break;
            case "loseLife":
                audioSrc.PlayOneShot(loseLifeSound, 0.3f);
                break;
            case "die":
                audioSrc.PlayOneShot(playerDeathSound, 0.3f);
                break;
            case "nextLevel":
                audioSrc.PlayOneShot(nextLevelSound, 0.6f);
                break;
        }
    }
}
