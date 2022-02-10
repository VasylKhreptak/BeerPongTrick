using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LineRenderer _lineRenderer;

    [Header("Preferences")]
    [SerializeField] private int _maxPointsCount = 100;
    [SerializeField] private float _distanceBetweenPoints = 0.1f;

    public void Show(Vector3 origin, Vector3 direction, float speed)
    {
        Vector3[] points = new Vector3[_maxPointsCount];
        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * _distanceBetweenPoints;

            Vector3 calculatedPosition = origin + speed * direction * time + Physics.gravity * time * time / 2f;

            points[i] = calculatedPosition;
            
            if (i > 0 && IsSomethingBetween(points[i - 1], points[i]))
            {
                _lineRenderer.positionCount = i + 1;
                
                break;
            }
        }

        _lineRenderer.SetPositions(points);
    }

    public void Clear()
    {
        _lineRenderer.positionCount = 0;
    }

    private bool IsSomethingBetween(Vector3 firstPoint, Vector3 secondPoint)
    {
        Ray ray = new Ray(firstPoint, secondPoint - firstPoint);

        float distance = Vector3.Distance(firstPoint, secondPoint);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            return true;
            
        }

        return false;
    }
}