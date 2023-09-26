using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private float _fadeTime = 1;
    public void Init(int value) {
        _text.text = value.ToString();

        var sequence = DOTween.Sequence();

        sequence.Insert(0, _text.DOFade(0, _fadeTime));
        sequence.Insert(0, _text.transform.DOMove(_text.transform.position + Vector3.up, _fadeTime));

        sequence.OnComplete(() => Destroy(gameObject));
    }
}
