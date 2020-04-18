using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectCounter : MonoBehaviour
{
    private static int _counter;
    //public string _soundPathRoot;
    public ObjectProperties[] _objectProperties;
    public List<string> objectsDelete;
    public List<string> objectTouchedForLooping;



    private void Awake()
    {
        _counter = 0;
        //_soundPathRoot = "file://" + Application.streamingAssetsPath + "/Sounds/";
        objectsDelete = new List<string>();
    }

    public int Counter
    {
        get
        {
            return _counter;
        }
        set
        {
            _counter = value;
        }
    }
    //public string SoundPathRoot
    //{
    //    get
    //    {
    //        return _soundPathRoot;
    //    }
    //    set
    //    {
    //        _soundPathRoot = value;
    //    }
    //}

    public ObjectProperties[] ObjectProperties
    {
        get
        {
            return _objectProperties;
        }
        set
        {
            _objectProperties = value;
        }
    }
    public List<string> ObjectsDelete
    {
        get
        {
            return objectsDelete;
        }
        set
        {
            objectsDelete = value;
        }
    }
    public List<string> ObjectTouchedForLooping
    {
        get
        {
            return objectTouchedForLooping;
        }
        set
        {
            objectTouchedForLooping = value;
        }
    }
}
