using System;
using System.Collections;
using UnityEngine;

public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float _shockWaveTime = 0.75f;

    private Coroutine _shockWaveCoroutine;

    private Material _material;

    private bool doShockWaveAnimation;

    private static int _waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        CallShockWave();
    }

    public void CallShockWave()
    {
        if (doShockWaveAnimation)
        {
            _shockWaveCoroutine = StartCoroutine(ShockWaveAction(transform.position.x, 1f));
        }
    }

    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat(_waveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / _shockWaveTime));
            _material.SetFloat(_waveDistanceFromCenter, lerpedAmount);

            yield return null;
        }
    }

    public void DoShockWave()
    {
        doShockWaveAnimation = true;
    }
    
    public void StopShockWave()
    {
        doShockWaveAnimation = false;
    }
}
