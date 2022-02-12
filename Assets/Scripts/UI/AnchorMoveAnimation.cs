using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class AnchorMoveAnimation : AnimationCore
    {
        [Header("References")]
        [SerializeField] private RectTransform _rectTransform;

        [Header("Preferences")]
        [SerializeField] private float _duration;
        [SerializeField] private Vector2 _startAnchorMin;
        [SerializeField] private Vector2 _startAnchorMax;
        [SerializeField] private Vector2 _targetAnchorMin;
        [SerializeField] private Vector2 _targetAnchorMax;
        [SerializeField] private AnimationCurve _animationCurve;

        private Tween _anchorMinTween;
        private Tween _anchorMaxTween;
        
        #region MonoBahaviour

        private void OnValidate()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnDestroy()
        {
            KillTweens();
        }

        #endregion

        private void KillTweens()
        {
            _anchorMinTween.Kill();
            _anchorMaxTween.Kill();
        }
        
        public override void Animate(bool state)
        {
            _rectTransform.anchorMin = state ? _startAnchorMin : _targetAnchorMin;
            _rectTransform.anchorMax = state ? _startAnchorMax : _targetAnchorMax;

            _anchorMinTween = _rectTransform.DOAnchorMin(state ? _targetAnchorMin : _startAnchorMin, _duration).
                SetEase(_animationCurve);
            _anchorMaxTween = _rectTransform.DOAnchorMax(state ? _targetAnchorMax : _startAnchorMax, _duration).
                SetEase(_animationCurve);
        }
    }
}