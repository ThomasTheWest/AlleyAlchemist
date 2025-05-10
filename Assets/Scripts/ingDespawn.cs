using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingDespawn : MonoBehaviour
{
    [SerializeField] float duration = 60.0f;
    [SerializeField] bool despawn = true;
    private float timer = 0f;

    private void Update()
    {
        if (despawn)
        {
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
