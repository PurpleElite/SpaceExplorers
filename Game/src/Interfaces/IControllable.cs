using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    interface IControllable
    {
        void Use_Pressed();

        void Up_Pressed();

        void Down_Pressed();

        void Left_Pressed();

        void Right_Pressed();

        void Use_Released();

        void Up_Released();

        void Down_Released();

        void Left_Released();

        void Right_Released();
    }
}
