using UnityEngine;
using Zenject;

namespace UI
{
    public class TapToPlayText : MonoBehaviour
    {
        [Inject]
        private LevelProvider _levelProvider;

        private void OnEnable()
        {
            if (_levelProvider.FinishedAllLevels())
            {
                gameObject.SetActive(false);
            }
        }
    }
}