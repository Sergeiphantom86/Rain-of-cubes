using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefab;

    void Start()
    {
        Show();
    }

    private void Show()
    {
        foreach(GameObject gameObject in _prefab)
        {
            Instantiate(gameObject);
        }
    }
}