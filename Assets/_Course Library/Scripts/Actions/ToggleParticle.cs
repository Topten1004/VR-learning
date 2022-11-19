using UnityEngine;

/// <summary>
/// Toggles particle system
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ToggleParticle : MonoBehaviour
{
    private ParticleSystem currentParticleSystem = null;
    private MonoBehaviour currentOwner = null;
    private DetectNearlyFire _detectNearlyFire;
    

    private void Awake()
    {
        currentParticleSystem = GetComponent<ParticleSystem>();
        _detectNearlyFire = GetComponentInParent<DetectNearlyFire>();
    }

    public void Play()
    {
        if (_detectNearlyFire != null)
        {
            _detectNearlyFire.gameObject.tag = "Fire";
        }
        currentParticleSystem.gameObject.tag = "Fire";
        currentParticleSystem.Play();
    }

    public void Stop()
    {
        if (_detectNearlyFire != null)
        {
            _detectNearlyFire.gameObject.tag = "Untagged";
        }
        currentParticleSystem.gameObject.tag = "Untagged";
        currentParticleSystem.Stop();
    }

    public void Toggle()
    {
        if (currentParticleSystem.isPlaying)
        {
            Stop();
        }else
        {
            Play();
        }
    }

    public void PlayWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == null)
        {
            currentOwner = this;
            Play();
        }
    }

    public void StopWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == this)
        {
            currentOwner = null;
            Stop();
        }
    }

    private void OnValidate()
    {
        if(currentParticleSystem)
        {
            ParticleSystem.MainModule main = currentParticleSystem.main;
            main.playOnAwake = false;
        }
    }
}
