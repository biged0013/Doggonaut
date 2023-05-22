using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip walkingClip, jumpClip, hitClip, hurtClip, barkClip, happyClip;
    [SerializeField] private AudioSource walkingSource, jumpSource, hitSource, hurtSource, barkSource, happySource;

    void Start()
    {
        // Get the AudioSource components attached to the player
        walkingSource = GetComponent<AudioSource>();
        jumpSource = transform.Find("JumpSource").GetComponent<AudioSource>();
        hitSource = transform.Find("HitSource").GetComponent<AudioSource>();
        hurtSource = transform.Find("HurtSource").GetComponent<AudioSource>();
        barkSource = transform.Find("BarkSource").GetComponent<AudioSource>();
        happySource = transform.Find("HappySource").GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        // Play the sound based on the name given
        switch (soundName)
        {
            case "Walking":
                walkingSource.clip = walkingClip;
                walkingSource.Play();
                break;
            case "Jump":
                jumpSource.clip = jumpClip;
                jumpSource.Play();
                break;
            case "Hit":
                hitSource.clip = hitClip;
                hitSource.Play();
                break;
            case "Hurt":
                hurtSource.clip = hurtClip;
                hurtSource.Play();
                break;
            case "Bark":
                barkSource.clip = barkClip;
                barkSource.Play();
                break;
            case "Happy":
                happySource.clip = happyClip;
                happySource.Play();
                break;
        }
    }
}
