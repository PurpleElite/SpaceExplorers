using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class Controller
    {
        // Declare a delegate type for processing input:
        public delegate void ProcessKeyDelegate();

        Dictionary<string, ProcessKeyDelegate> keyPressDict = new Dictionary<string, ProcessKeyDelegate>();
        Dictionary<string, ProcessKeyDelegate> keyReleaseDict = new Dictionary<string, ProcessKeyDelegate>();
        IControllable control = null;
        Room activeRoom = null;
        Stack<IControllable> controlHistory;

        //Default Controls
        public Controller()
        {
            controlHistory = new Stack<IControllable>();
            keyPressDict.Add("E", new ProcessKeyDelegate(Use_Pressed));
            keyPressDict.Add("W", new ProcessKeyDelegate(Up_Pressed));
            keyPressDict.Add("A", new ProcessKeyDelegate(Left_Pressed));
            keyPressDict.Add("S", new ProcessKeyDelegate(Down_Pressed));
            keyPressDict.Add("D", new ProcessKeyDelegate(Right_Pressed));
            keyReleaseDict.Add("E", new ProcessKeyDelegate(Use_Released));
            keyReleaseDict.Add("W", new ProcessKeyDelegate(Up_Released));
            keyReleaseDict.Add("A", new ProcessKeyDelegate(Left_Released));
            keyReleaseDict.Add("S", new ProcessKeyDelegate(Down_Released));
            keyReleaseDict.Add("D", new ProcessKeyDelegate(Right_Released));
        }

        //Public Methods
        public void Set_Control(IControllable newControl)
        {
            controlHistory.Push(control);
            control = newControl;
        }

        public void Return_Control()
        {
            control = controlHistory.Pop();
        }

        public void Set_Room(Room room)
        {
            activeRoom = room;
        }

        public void Key_Press(String key)
        {
            try
            {
                ProcessKeyDelegate action = keyPressDict[key];
                action();
            }
            catch(KeyNotFoundException){ } //do nothing
        }

        public void Key_Release(String key)
        {
            try
            {
                ProcessKeyDelegate action = keyReleaseDict[key];
                action();
            }
            catch (KeyNotFoundException) { } //do nothing
        }

        //Key Press Methods
        private void Use_Pressed()
        {
            if (control != null && activeRoom != null)
                control.Use_Pressed();
        }

        private void Up_Pressed()
        {
            if (control != null)
                control.Up_Pressed();
        }

        private void Down_Pressed()
        {
            if (control != null)
                control.Down_Pressed();
        }

        private void Left_Pressed()
        {
            if (control != null)
                control.Left_Pressed();
        }

        private void Right_Pressed()
        {
            if (control != null)
                control.Right_Pressed();
        }

        private void Use_Released()
        {
            if (control != null)
                control.Use_Released();
        }

        private void Up_Released()
        {
            if (control != null)
                control.Up_Released();
        }

        private void Down_Released()
        {
            if (control != null)
                control.Down_Released();
        }

        private void Left_Released()
        {
            if (control != null)
                control.Left_Released();
        }

        private void Right_Released()
        {
            if (control != null)
                control.Right_Released();
        }
    }
}
