using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class StartupAnimation : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AnimationCore _animation;

        [Header("Preferences")]
        [SerializeField] private float _delay;
        [SerializeField] private bool _state = true;

        private Tween _waitTween;

        #region MonoBahaviour

        private void OnEnable()
        {
            _waitTween.Kill();
            _waitTween = this.DOWait(_delay).OnComplete(() => { _animation.Animate(_state); });
        }

        private void OnValidate()
        {
            _animation = GetComponent<AnimationCore>();
        }

        private void OnDestroy()
        {
            _waitTween.Kill();
        }

        #endregion
    }
}