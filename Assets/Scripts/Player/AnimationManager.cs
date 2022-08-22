using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour{

    [SerializeField] Animator playerAnimator;

    public void EnableRootMotion(bool enable =  true) => playerAnimator.applyRootMotion = enable;
}
