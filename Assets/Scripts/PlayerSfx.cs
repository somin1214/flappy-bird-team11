using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource source;
    public AudioClip wing, point, hit, die;
    [Range(0f, 1f)] public float volume = 0.8f;
    [Range(0f, 0.3f)] public float pitchJitter = 0.05f;

    void Awake()
    {
        if (!source) source = GetComponent<AudioSource>();
        //기본설정
        if (source) { source.playOnAwake = false; source.loop = false; source.spatialBlend = 0f; source.dopplerLevel = 0f; }
    }

    public void PlayWing() { Play(wing); }      //기본or이동
    public void PlayPoint() { Play(point); }    //점수흭득
    public void PlayHit() { Play(hit); }        //충돌
    public void PlayDie() { Play(die); }        //사망

    void Play(AudioClip clip)
    {
        if (!source || !clip) return;
        var p = 1f + Random.Range(-pitchJitter, pitchJitter);
        source.pitch = p;
        source.PlayOneShot(clip, volume);
    }
}
