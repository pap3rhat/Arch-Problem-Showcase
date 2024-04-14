using UnityEngine;

public class OuterPrefabSpawner : MonoBehaviour
{
    [SerializeField] GameObject _outerPrefab;

    private void Awake()
    {

        // Spawning Prefab B
        GameObject go = Instantiate(_outerPrefab, transform.position, transform.rotation);
        go.GetComponent<VfxControllerOnOuterPrefab>().SetColor(Color.green);

        // Spawning Prefab C
        GameObject go2 = Instantiate(_outerPrefab, transform.position + Vector3.forward * 5, transform.rotation);
        go2.GetComponent<VfxControllerOnOuterPrefab>().SetColor(Color.blue);
    }
}
