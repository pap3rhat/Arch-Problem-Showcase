using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ArchUpdate : MonoBehaviour
{
    [SerializeField] private VisualEffect _archVFX;

    private Vector3 _sourcePosition;
    private Vector3 _sinkPosition;
    private Color _color;


    /*---  Public Getter and Setter ----------------------------------------------------------------------------------------------------------------------------------*/
    
    // Arch
    public Vector3 SourcePosition
    {
        get => _sourcePosition;
        set
        {
            _sourcePosition = value;
            if (_sinkPosition != null)
            {
                UpdateVFXArcProperty();
            }
        }
    }
    public Vector3 SinkPosition
    {
        get => _sinkPosition;
        set
        {
            _sinkPosition = value;
            if (_sourcePosition != null)
            {
                UpdateVFXArcProperty();
            }
        }
    }

    //public Color Color
    //{
    //    get => _color;
    //    set
    //    {
    //        _color = value;
    //        _archVFX.SetVector4("Arch Color", _color);
    //    }
    //}

    /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* Sets points used for bezier curve given source node and sink node*/
    private void UpdateVFXArcProperty()
    {
        Vector3 middlePos = _sourcePosition + .5f * (_sinkPosition - _sourcePosition);
        Vector3 middlePosHeight = middlePos + Vector3.Normalize(middlePos) * Vector3.Distance(_sourcePosition, _sinkPosition);

        _archVFX.SetVector3("Source", _sourcePosition);
        _archVFX.SetVector3("Bezier 2", Vector3.Lerp(_sourcePosition, middlePosHeight, 0.75f));
        _archVFX.SetVector3("Bezier 3", Vector3.Lerp(middlePosHeight, _sinkPosition, 0.25f));
        _archVFX.SetVector3("Sink", _sinkPosition);
    }
}
