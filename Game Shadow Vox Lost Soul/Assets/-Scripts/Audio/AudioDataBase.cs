using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioDataBase : MonoBehaviour
{
    [SerializeField] AudioData[] _audioData;
    private Dictionary<string, AudioData> _audioDataDictionary;

    private void Awake()
    {
        _audioDataDictionary = new Dictionary<string, AudioData>();
    }

    private void OnEnable()
    {
        _audioDataDictionary = _audioData.ToDictionary(audioData => audioData.AudioName, audioData => audioData);
    }

    public AudioData GetAudio(string _audioName)
    {
        if (_audioDataDictionary.TryGetValue(_audioName, out AudioData audioData))
            return audioData;

        return null;
    }
}
