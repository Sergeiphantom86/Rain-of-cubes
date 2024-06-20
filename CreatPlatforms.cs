using System.Collections.Generic;
using UnityEngine;

public class CreatPlatforms : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;

    void Start()
    {
        Show();
    }

    private void Show()
    {
        foreach(GameObject prefab in _prefabs)
        {
            Instantiate(prefab);
        }
    }
}
