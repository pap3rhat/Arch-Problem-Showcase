using UnityEngine;

public class VfxControllerOnOuterPrefab : MonoBehaviour
{
    [SerializeField] ArchController _vfx;

    private void Awake()
    {
        // Setting position of arch
        _vfx.SourcePosition = transform.position + 5 * Vector3.forward;
        _vfx.SinkPosition = transform.position;
    }


    // Gets called from OuterPRefabSpawner
    public void SetColor(Color _color)
    {
        _vfx.Color = _color;
    }

}
