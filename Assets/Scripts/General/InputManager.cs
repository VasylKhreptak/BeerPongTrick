using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField, Range(0f, 100f)]
    private float _screenDragDistancePercentage;

    private Vector2 _firstPoint;
    private Vector2 _lastPoint;

    private float _dragDistance;

    public Action<Vector2, Vector2> onSwipeUp;
    public Action<Vector2, Vector2> onSwipeDown;
    public Action<Vector2, Vector2> onSwipeRight;
    public Action<Vector2, Vector2> onSwipeLeft;
    public Action<Vector2, Vector2> onEndMove;
    public Action<Vector2, Vector2> onMoved;
    public Action<Vector2> onTouch;

    private void Awake()
    {
        _dragDistance = Screen.height * _screenDragDistancePercentage / 100;
    }

    private void Update()
    {
        if (Input.touchCount < 1) return;

        Touch touch = Input.GetTouch(0);

        ProcessTouch(touch);
    }

    private void ProcessTouch(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                _firstPoint = touch.position;
                _lastPoint = touch.position;

                break;
            case TouchPhase.Moved:
                _lastPoint = touch.position;
                onMoved?.Invoke(_firstPoint, _lastPoint);
                
                break;
            case TouchPhase.Ended:
                _lastPoint = touch.position;
                onEndMove?.Invoke(_firstPoint, _lastPoint);
                ProcessSwipe();

                break;
        }
    }

    private void ProcessSwipe()
    {
        if (IsSwipe())
        {
            if (IsHorizontalSwipe())
            {
                if (IsRightSwipe())
                {
                    onSwipeRight?.Invoke(_firstPoint, _lastPoint);
                }
                else
                {
                    onSwipeLeft?.Invoke(_firstPoint, _lastPoint);
                }
            }
            else
            {
                if (IsUpSwipe())
                {
                    onSwipeUp?.Invoke(_firstPoint, _lastPoint);
                }
                else
                {
                    onSwipeDown?.Invoke(_firstPoint, _lastPoint);
                }
            }
        }
        else
        {
            onTouch?.Invoke(_firstPoint);
        }
    }

    private bool IsSwipe()
    {
        return Mathf.Abs(_lastPoint.x - _firstPoint.x) > _dragDistance ||
               Mathf.Abs(_lastPoint.y - _firstPoint.y) > _dragDistance;
    }

    private bool IsHorizontalSwipe()
    {
        return Mathf.Abs(_lastPoint.x - _firstPoint.x) > Mathf.Abs(_lastPoint.y - _firstPoint.y);
    }

    private bool IsRightSwipe()
    {
        return _lastPoint.x > _firstPoint.x;
    }

    private bool IsUpSwipe()
    {
        return _lastPoint.y > _firstPoint.y;
    }
}