using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] List <AudioSource> _birds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayRandomBird(1, 10));
    }

    IEnumerator PlayRandomBird(int minDelay, int maxDelay)
    {
        while (true)
        {
            var delay = Random.Range(minDelay, maxDelay);
            var selection = Random.Range(0, _birds.Count);
            _birds[selection].Play();
            yield return new WaitForSeconds(delay);
        }
        
    }
}
