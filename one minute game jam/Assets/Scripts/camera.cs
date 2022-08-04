using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera : MonoBehaviour
{

    public Transform PlayerrTransform;

    private Vector3 cmOffset;

    [Range(0.001f, 1.0f)]
    public float smoothness = 0.5f;

    void Start()
    {
        cmOffset = transform.position - PlayerrTransform.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPos = PlayerrTransform.position + cmOffset;
        newPos.y = Mathf.Clamp(newPos.y, 0, 0);
        newPos.x = Mathf.Clamp(newPos.x, -7.2f, 7.2f);
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}