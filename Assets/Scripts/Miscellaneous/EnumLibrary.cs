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
    IdleToRunTree = 0,
    FallingIdle = 0,
    FirstJumping = 1,
    DoubleJumpFlip = 1,
    DashPose = 1,
    TrampolineJump = 1,
    FlyPose = 3,
    SpinPose = 2
}
