using System.Collections.Generic;
using UnityEngine;

public class DeathSoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<AudioSource> deathSounds;

    public List<AudioSource> GetDeathSounds()
    {
        return this.deathSounds;
    }
}
