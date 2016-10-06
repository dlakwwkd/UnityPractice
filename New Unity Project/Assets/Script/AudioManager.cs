using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    static public AudioManager _instance = null;
    public static AudioManager instance
    {
        get { return _instance; }
    }

    public AudioClip music = null;

    AudioSource audio = null;

	void Start ()
    {
        if (_instance == null)
            _instance = this;

        if(music != null)
        {
            audio = GetComponent<AudioSource>();
            audio.clip = music;
            audio.loop = true;
            audio.Play();
        }
	}

    public void PlaySfx(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
