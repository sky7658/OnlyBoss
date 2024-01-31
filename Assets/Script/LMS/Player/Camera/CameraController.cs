using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform maxZoomInTransform;
    [SerializeField] private Transform maxZoomOutTransform;

    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float distance = 8f;
    private float maxDistance = 8f;
    private float smoothTime = 0.2f;
    private float rotSpeed = 5f;
    private Vector3 velocity = Vector3.zero;

    private Camera pCamera;

    private void Awake()
    {
        pCamera = GetComponent<Camera>();
    }

    void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        maxDistance = 8f;
        smoothTime = 0.2f;
        rotSpeed = 5f;
    }

    private void CameraZoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        if (distance < 0f) distance = 0f;
        if (distance > maxDistance) distance = maxDistance;

        Vector3 _reverseDistance = new Vector3(0f, 0f, distance);

        transform.localPosition = Vector3.SmoothDamp(
            transform.localPosition, maxZoomInTransform.localPosition - maxZoomOutTransform.localRotation * _reverseDistance, ref velocity, smoothTime);

        var _rot = Quaternion.Lerp(maxZoomInTransform.localRotation, maxZoomOutTransform.localRotation, distance / maxDistance);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, _rot, rotSpeed * Time.deltaTime);
    }

    void Update()
    {
        CameraZoom();
    }
}