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


    public AudioSource sourceCri;
    public bool finish;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(PlayMusic());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(finish)
        {
            finish = false;
            StartCoroutine(PlayMusic());
        }
	}


    
    public IEnumerator PlayMusic()
    {
        sourceMusic.clip = clipAmbianceOne;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceOne.length);

        sourceMusic.clip = clipAmbianceTwo;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceTwo.length);

        sourceMusic.clip = clipAmbianceThree;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceThree.length);

        sourceMusic.clip = clipAmbianceFour;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceFour.length);

        sourceMusic.clip = clipAmbianceFive;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceFive.length);

        sourceMusic.clip = clipAmbianceSix;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceSix.length);

        sourceMusic.clip = clipAmbianceSeven;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceSeven.length);

        sourceMusic.clip = clipAmbianceEight;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceEight.length);

        sourceMusic.clip = clipAmbianceNine;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceNine.length);

        sourceMusic.clip = clipAmbianceTen;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceTen.length);

        sourceMusic.clip = clipAmbianceEleven;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceEleven.length);

        sourceMusic.clip = clipAmbianceTwelve;
        sourceMusic.Play();
        yield return new WaitForSeconds(clipAmbianceTwelve.length);
        finish = true;
        yield return null;
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
        sourceFX.pitch = 1;
        sourceFX.Play();
        //yield return new WaitForSeconds(sourceFX.clip.length);
    }


    public void PlayCri()
    {
        sourceCri.pitch = 0.25f;
        sourceCri.Play();
    }
}
