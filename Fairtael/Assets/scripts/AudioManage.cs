
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [Header("audio sources")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource effects;

    [Header("audio clips")]
    public AudioClip bgMusic;
    public AudioClip enemyHit;
    public AudioClip enemyShoot;
    public AudioClip enemyDeath;
    public AudioClip playerHit;
    public AudioClip playerShoot;
    public AudioClip playerDeath;
    public AudioClip itemObtain;
    public AudioClip pedestal;
    public AudioClip ladder;
    public AudioClip click;

    private void Start()
    {
        music.clip = bgMusic;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }
}
