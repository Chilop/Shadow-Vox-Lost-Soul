using System;
using GameShadow;

public interface ISceneTransition
{
    void TransitionToScene(string sceneName, SceneTransitionManager.TransitionType transitionType = SceneTransitionManager.TransitionType.Fade);
    void Transition(Action action, SceneTransitionManager.TransitionType transitionType = SceneTransitionManager.TransitionType.Fade);
}
