using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public enum AnimType : int { Idle, IdleE, IdleW, RunN, RunNE, RunE, RunSE, RunS, RunSW, RunW, RunNW };

    static public class AnimationType
    {
        static public bool IsMovement(Animation anim)
        {
            if (anim == null)
            {
                return false;
            }
            else if (anim.Type == AnimType.RunN ||
                anim.Type == AnimType.RunNE ||
                anim.Type == AnimType.RunE ||
                anim.Type == AnimType.RunSE ||
                anim.Type == AnimType.RunS ||
                anim.Type == AnimType.RunSW ||
                anim.Type == AnimType.RunW ||
                anim.Type == AnimType.RunNW)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
