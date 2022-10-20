public enum WeaponType{
    none,
    bow
}

public enum GravityType{
    onGrounded,
    onFalling,
    onJumping
}

public enum Animations{
    /*
        - Each animation name correspond to a animator anim, the name has to be the same(case sensitive)
        - Each anim has a priority number, this will tell which animation has the priority to execute
    */
    IdleToRunTree,
    BreathingIdle,
    SilentWalking,
    Walking,
    Running,
    PanicRunning,
    FallingIdle,
    FirstJumping,
    DoubleJumpFlip,
    DashPose,
    TrampolineJump,
    FlyPose,
    SpinPose, 
    StrikeForwardKick
}

public enum ElementType{
    Ground,
    Normal,
    Fire,
    Water, 
    Wind
}

public enum Layers{
    Default = 0,
    TransparentFX = 1,
    IgnoreRaycast = 2,
    Water = 4,
    UI = 5,
    Ground = 6,
    GhostLayer = 7
}

public enum Tags{
    InterestObject,
    Ground
}
