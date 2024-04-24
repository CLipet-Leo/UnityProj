using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    [Header("Bobbing")]
    public bool enable = true;
    [Range(0, 0.1f)] public float amplitude = 0.015f;
    [Range(0, 30)] public float frequency = 10.0f;

    public Transform Camera = null;
    public Transform Head = null;

    private float toggleSpeed = 2.5f;
    private Vector3 startPos;
    private PlayerScript playerScript;

    private void Awake()
    {
        playerScript = GetComponent<PlayerScript>();
        startPos = Camera.localPosition;
    }

    void Update()
    {
        if (!enable) return;

        CheckMotion();
        ResetPosition();
        Camera.LookAt(FocusTarget());
    }

    /* BOBBING */

    private void PlayMotion(Vector3 motion) 
    {
        Camera.localPosition += motion;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(playerScript.rb.velocity.x, 0, playerScript.rb.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!playerScript.grounded) return;

        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (Camera.localPosition == startPos) return;
        Camera.localPosition = Vector3.Lerp(Camera.localPosition, startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + Head.localPosition.y, transform.position.z);
        pos += Head.forward * 15.0f;
        return pos;
    }
}
