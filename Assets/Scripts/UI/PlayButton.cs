using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class PlayButton : MonoBehaviour
    {
        [Inject] private LevelProvider _levelProvider;
        
        public void LoadLevel()
        {
            string nextLevel = _levelProvider.GetNextUnfinishedLevel();
            
            if (nextLevel != null)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}