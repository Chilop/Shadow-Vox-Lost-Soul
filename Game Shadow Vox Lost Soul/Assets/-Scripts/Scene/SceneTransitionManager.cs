using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameShadow
{
    

    public class SceneTransitionManager : Singleton<ISceneTransition>, ISceneTransition
    {
        [Header("COMPONENTS")]
            [SerializeField] private CanvasGroup _mainCanvasGroup;
            [SerializeField] private GameObject _backgroundPanel;
            
            [Header("CONFIGURATIONS")]
            [SerializeField] private float _transitionDuration = 1;
            
            public void TransitionToScene(string sceneName, TransitionType transitionType)
            {
                switch (transitionType)
                {
                    case TransitionType.Fade:
                        TransitionFade(() => GoToScene(sceneName)).Forget();
                        break;
                }
            }

            public void Transition(Action action, TransitionType transitionType)
            {
                switch (transitionType)
                {
                    case TransitionType.Fade:
                        TransitionFade(action).Forget();
                        break;
                }
            }

            private async UniTaskVoid TransitionFade(Action onTransition)
            {
                _mainCanvasGroup.alpha = 0;
                _mainCanvasGroup.gameObject.SetActive(true);
                await _mainCanvasGroup.DOFade(1, _transitionDuration).AsyncWaitForCompletion();
                
                onTransition?.Invoke();
                
                await _mainCanvasGroup.DOFade(0, _transitionDuration).AsyncWaitForCompletion();
                _mainCanvasGroup.gameObject.SetActive(false);
            }
            
            private async UniTaskVoid TransitionSlide(Action onTransition)
            {
                _mainCanvasGroup.gameObject.SetActive(true);
                var mainCanvasRect = ((RectTransform)_mainCanvasGroup.transform).rect;
                var screenWidth = mainCanvasRect.width;
                
                _backgroundPanel.transform.localPosition = new Vector3(screenWidth, 0, 0);
                await _backgroundPanel.transform.DOLocalMoveX(0, _transitionDuration).AsyncWaitForCompletion();
                
                onTransition?.Invoke();
                
                await _backgroundPanel.transform.DOLocalMoveX(screenWidth, _transitionDuration).AsyncWaitForCompletion();
                _mainCanvasGroup.gameObject.SetActive(false);
            }

            private void GoToScene(string sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
        
        
        public enum TransitionType
        {
            Fade
        }
    }
}