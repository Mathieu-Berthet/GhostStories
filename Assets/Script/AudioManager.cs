using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Ambiance")]
    public AudioSource sourceMusic;

    public AudioClip clipAmbianceOne;
    public AudioClip clipAmbianceTwo;
    public AudioClip clipAmbianceThree;
    public AudioClip clipAmbianceFour;
    public AudioClip clipAmbianceFive;
    public AudioClip clipAmbianceSix;
    public AudioClip clipAmbianceSeven;
    public AudioClip clipAmbianceEight;
    public AudioClip clipAmbianceNine;
    public AudioClip clipAmbianceTen;
    public AudioClip clipAmbianceEleven;
    public AudioClip clipAmbianceTwelve;

    [Header("FX")]
    public AudioSource sourceFX;
    public AudioSource sourceFX2;
    public AudioClip ghostAppearFX;
    public AudioClip hauntingGhostFX;
    public AudioClip hauntingAdvanceFX;
    public AudioClip hauntingFX;
    public AudioClip horrorScreamFX;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(PlayMusic());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    
    public IEnumerator PlayMusic()
    {
        sourceMusic.clip = clipAmbianceOne;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceOne.length);

        sourceMusic.clip = clipAmbianceTwo;
        sourceMusic.Play();
    }

    public IEnumerator PlayApparitionFX(AudioClip fxToPlay, float timer)
    {
        sourceFX.clip = fxToPlay;
        sourceFX.Play();
        yield return new WaitForSeconds(timer);
        sourceFX.Stop();
    }

    public IEnumerator PlayHauntingGhostFX(AudioClip fxToPlay, float timer)
    {
        yield return new WaitForSeconds(1.5f);
        sourceFX2.clip = fxToPlay;
        sourceFX2.Play();
        yield return new WaitForSeconds(timer);
        sourceFX2.Stop();
    }


    public IEnumerator PlayHauntingAdvanceFX(AudioClip fxHauntToPlay)
    {
        sourceFX.clip = fxHauntToPlay;
        sourceFX.Play();
        yield return new WaitForSeconds(sourceFX.clip.length);
    }


    public IEnumerator PlayHauntingFX(AudioClip fxHauntToPlay, AudioClip fxHauntToPlayTwo, float timerHaunt)
    {
        sourceFX.clip = fxHauntToPlay;
        sourceFX.Play();
        yield return new WaitForSeconds(timerHaunt);

        sourceFX.clip = fxHauntToPlayTwo;
        sourceFX.Play();
        //yield return new WaitForSeconds(sourceFX.clip.length);
    }

}
