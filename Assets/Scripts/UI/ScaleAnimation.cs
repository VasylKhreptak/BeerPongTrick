using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class ScaleAnimation : AnimationCore
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Preferences")]
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _startScale;
        [SerializeField] private Vector3 _targetSfcale;
        [SerializeField] private AnimationCurve _animationCurve;

        private Tween _scaleTween;

        private Action _onComplete;
        
        #region MonoBahaviour

        private void OnValidate()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnDestroy()
        {
            _scaleTween.Kill();
        }

        #endregion

        public override  void Animate(bool state)
        {
            _transform.localScale = state ? _startScale : _targetSfcale;

            _scaleTween = _transform.DOScale(state ? _targetSfcale : _startScale, _duration).SetEase(_animationCurve);
        }
    }
}