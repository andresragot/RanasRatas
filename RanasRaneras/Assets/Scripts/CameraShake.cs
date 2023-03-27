using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duracion, float magnitud)
    {
        Vector2 originalPos = new Vector2(0, 0);

        float tiempoMinimo = 0f;

        while(tiempoMinimo < duracion)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitud;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitud;

            transform.localPosition = new Vector2(xOffset, yOffset);

            tiempoMinimo += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
