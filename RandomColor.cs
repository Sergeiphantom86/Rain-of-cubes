using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class RandomColor : MonoBehaviour
{
    [SerializeField] private Color _default;
    private readonly List<Color> _colors = new();

    public void Replace()
    {
        AddColors();

        gameObject.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Count)];
    }

    public void Default()
    {
        gameObject.GetComponent<Renderer>().material.color = _default;
    }

    private void AddColors()
    {
        _colors.Add(Color.green);
        _colors.Add(Color.blue);
        _colors.Add(Color.magenta);
        _colors.Add(Color.yellow);
        _colors.Add(Color.white);
        _colors.Add(Color.cyan);
        _colors.Add(Color.red);
    }
}