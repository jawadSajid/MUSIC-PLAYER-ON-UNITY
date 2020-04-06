using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sprite[] sprite;
    public int count = 0;
    public Image img;

    bool pause = false;
    bool flag = false;
    bool asju = false;

    public AudioClip[] musicClips;
    private AudioSource source;
    private int currentTrack;

    public Text clipTitleText;
    public Text clipTimeText;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;

    public Slider Volume;
    public Slider Music;

    void Awake()
    {
        sprite = Resources.LoadAll<Sprite>("Sprites");
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
        // PlayMusic();
    }
    public void loop()
    {
        source.loop = true;
        int value3 = (int)Music.maxValue;
        int value4 = (int)source.clip.length;
        if (value3 == value4)
        {
            Music.value = 0;
        }
    }
    public void PlayMusic()
    {

        // source.Play();

        if (flag == false)
        {
            currentTrack--;
            if (source.isPlaying)
            {
                return;
            }
            count--;
            NextTitle();
            flag = true;
        }
        else
        {
            source.UnPause();
            pause = false;
            asju = false;
        }

        //Music.maxValue = source.time;
        /* currentTrack--;
         if (currentTrack < 0)
         {
             currentTrack = musicClips.Length - 1;
         }*/

        StartCoroutine("WaitforMusicEnd");
    }
    IEnumerator WaitforMusicEnd()
    {
        int value1 = (int)Music.maxValue;
        int value3 = (int)source.clip.length;

        while (source.isPlaying)
        {
            playTime = (int)source.time;
            ShowPlayTime();
            yield return null;
        }

        if (!source.isPlaying)
        {
            if (asju == false)
            {
                NextTitle();
            }
        }
    }
    public void NextTitle()
    {
        pause = false;
        source.loop = false;
        source.Stop();
        currentTrack++;

        if (currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //Show Title
        ShowCurrentTitle();
        Music.value = 0;

        NextImage();

        StartCoroutine("WaitforMusicEnd");
    }

    public void NextImage()
    {
        if (count == sprite.Length - 1)
        {
            count = 0;
            img.sprite = sprite[count];
        }
        else
        {
            count++;
            img.sprite = sprite[count];
        }
    }

    public void PreviousImage()
    {
        if (count == 0)
        {
            count = sprite.Length - 1;
            img.sprite = sprite[count];
        }
        else
        {
            count--;
            img.sprite = sprite[count];
        }
    }
    public void PreviousTitle()
    {
        pause = false;
        source.loop = false;
        source.Stop();
        currentTrack--;

        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //Show Title
        ShowCurrentTitle();
        Music.value = 0;

        PreviousImage();

        StartCoroutine("WaitforMusicEnd");
    }
    public void StopMusic()
    {
        source.loop = false;
        //StopAllCoroutines();
        StopCoroutine("WaitforMusicEnd");
        source.Stop();
        source.time = Music.value;
    }
    public void MuteMusic()
    {
        source.mute = !source.mute;
    }
    void ShowCurrentTitle()
    {
        clipTitleText.text = source.clip.name;
        fullLength = (int)source.clip.length;

        int value = (int)Music.maxValue;
        int value2 = (int)source.clip.length;
        if (value == value2)
        {
            Music.value = 0;
        }
    }
    void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        clipTimeText.text = minutes + ":" + seconds.ToString("D2") + "/" + ((fullLength / 60) % 60) + ":" + (fullLength % 60).ToString("D2");
    }
    public void VolumeSlider()
    {
        source.volume = Volume.value;
    }
    public void MusicSlider()
    {
        //SourceTime();
        source.time = source.clip.length * Music.value;
        Music.value = source.time / source.clip.length;

    }

    public void ILikeTheWay()
    {
        currentTrack = 8;
        count = 9;
        NextTitle();
        // NextImage();

    }

    public void Entertainer()
    {
        currentTrack = 9;
        count = 10;
        NextTitle();
    }

    public void MillionDreams()
    {
        currentTrack = 7;
        count = 8;
        NextTitle();
    }

    public void TerribleThings()
    {
        currentTrack = 6;
        count = 7;
        NextTitle();
    }

    public void SYML()
    {
        currentTrack = 5;
        count = 6;
        NextTitle();
    }

    public void Heartbeat()
    {
        currentTrack = 4;
        count = 5;
        NextTitle();
    }

    public void Damaged()
    {
        currentTrack = 3;
        count = 4;
        NextTitle();
    }

    public void PeterManos()
    {
        currentTrack = 2;
        count = 3;
        NextTitle();
    }

    public void RunToYou()
    {
        currentTrack = 1;
        count = 2;
        NextTitle();
        //StartCoroutine("WaitforMusicEnd");
    }

    public void IlikeMebetter()
    {
        currentTrack = 0;
        count = 1;
        NextTitle();
        //StartCoroutine("WaitforMusicEnd");


    }

    public void FindingHope()
    {
        currentTrack = -1;
        count = 0;
        NextTitle();
        //StartCoroutine("WaitforMusicEnd");


    }

    public void Pause()
    {
        if (pause == false)
        {
            source.Pause();
            pause = true;
            asju = true;
        }
        else
        {
            source.UnPause();
            pause = false;
            asju = false;
        }
    }
}
