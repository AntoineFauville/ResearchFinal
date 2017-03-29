using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour {
	public MovieTexture movie;

	void Start()
	{
		movie.Play();
		StartCoroutine("waitForMovieEnd");
	}

	IEnumerator waitForMovieEnd()
	{

		while(movie.isPlaying) // while the movie is playing
		{
			yield return new WaitForEndOfFrame();
		}
		// after movie is not playing / has stopped.
		onMovieEnded();
	}

	void onMovieEnded()
	{
		//Debug.Log("Movie Ended!");
		AsyncOperation async = Application.LoadLevelAsync ("PremiereScene");
		//Application.LoadLevel("Splash Screen");

	}
}
