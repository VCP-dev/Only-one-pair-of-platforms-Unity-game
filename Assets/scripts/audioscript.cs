using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour
{
    public static AudioClip cherrysound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
         cherrysound=Resources.Load<AudioClip>("gun-firing-sound-2");
          audioSrc=GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        audioSrc.PlayOneShot(cherrysound);
    }
}
