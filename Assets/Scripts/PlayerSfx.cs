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
        //�⺻����
        if (source) { source.playOnAwake = false; source.loop = false; source.spatialBlend = 0f; source.dopplerLevel = 0f; }
    }

    public void PlayWing() { Play(wing); }      //�⺻or�̵�
    public void PlayPoint() { Play(point); }    //����ŉ��
    public void PlayHit() { Play(hit); }        //�浹
    public void PlayDie() { Play(die); }        //���

    void Play(AudioClip clip)
    {
        if (!source || !clip) return;
        var p = 1f + Random.Range(-pitchJitter, pitchJitter);
        source.pitch = p;
        source.PlayOneShot(clip, volume);
    }
}
