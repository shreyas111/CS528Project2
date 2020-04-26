using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class ObjectProperties
{
    public string _shape;
    public string _colorName;
    public Color _color;
    public Material _mat;


    public string _audioClipName;
    public bool _isAudioLooped;
    [SerializeField]
    public AudioClip _audioClip;

    public string Shape
    {
        get
        {
            return _shape;
        }
        set
        {
            _shape = value;
        }
    }

    public string ColorName
    {
        get
        {
            return _colorName;
        }
        set
        {
            _colorName = value;
        }
    }

    public Color Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
        }
    }

    public Material Mat
    {
        get
        {
            return _mat;
        }
        set
        {
            _mat = value;
        }
    }

    public string AudioClipName
    {
        get
        {
            return _audioClipName;
        }
        set
        {
            _audioClipName = value;
        }
    }

    public bool IsAudioLooped
    {
        get
        {
            return _isAudioLooped;
        }
        set
        {
            _isAudioLooped = value;
        }
    }

    public AudioClip AudioClip
    {
        get
        {
            return _audioClip;
        }
        set
        {
            _audioClip = value;
        }
    }


}
