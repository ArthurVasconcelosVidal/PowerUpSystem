using  System.Collections.Generic;
namespace StructLibrary{
    public struct MinMaxFloat {
        public float Min { get; set; }
        public float Max { get; set; }
        public MinMaxFloat(float min, float max){
            Min = min;
            Max = max;
        }
    }
    
    public struct AnimationsDictonary {
        public static Dictionary<Animations,int> animations = new Dictionary<Animations,int>{
            /*
                - Each animation name correspond to a animator anim, the name has to be the same(case sensitive)
                - Each anim has a priority number, this will tell which animation has the priority to execute
            */
            {Animations.IdleToRunTree,0},
            {Animations.FallingIdle,0},
            {Animations.FirstJumping,1},
            {Animations.DoubleJumpFlip,1},
            {Animations.DashPose,1},
            {Animations.TrampolineJump,1},
            {Animations.FlyPose,3},
            {Animations.SpinPose,2},
        };
    }

}

