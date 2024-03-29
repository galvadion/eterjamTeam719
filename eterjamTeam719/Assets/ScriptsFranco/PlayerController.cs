﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAuxController : MonoBehaviour
{
    [Header ("Movement")]
    public float speed;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3((h * speed * Time.deltaTime), (v * speed * Time.deltaTime), 0f);

        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
