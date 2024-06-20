using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RandomColorAssigner), typeof(Rigidbody))]

public class Cube: MonoBehaviour
{
    private bool _notHasTouched;

    public event Action<Cube> LifeSpanEnded;

    private void Start()
    {
        _notHasTouched = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform _) && _notHasTouched)
        {
            gameObject.AddComponent<RandomColorAssigner>().Replace();

            StartCoroutine(ItemShutdownTimer());

            _notHasTouched = false;
        }
    }

    private IEnumerator ItemShutdownTimer()
    {
        int min = 2;
        int max = 6;

        float delay = UnityEngine.Random.Range(min, max);

        yield return new WaitForSeconds(delay);

        DisableItem();
    }

    private void DisableItem()
    {
        gameObject.SetActive(false);

        ReturnDefaultValues();
        
        LifeSpanEnded?.Invoke(this);
    }

    private void ReturnDefaultValues()
    {
        gameObject.AddComponent<RandomColorAssigner>().Default();
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.rotation = new Quaternion();
        _notHasTouched = true;
    }
}
