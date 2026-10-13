using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

public static AudioManager instancia;
public AudioSource audioSourceBalao;
public AudioClip BalaoAudio;

    // Start is called before the first frame update
    private void Awake()
    {
        instancia = this;
    }

    // Update is called once per frame
    public void SomBalao()
    {
        audioSourceBalao.PlayOneShot(BalaoAudio);
    }
}
