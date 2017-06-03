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
        Character player = null;

        //Default Controls
        public Controller()
        {
            keyPressDict.Add("W", new ProcessKeyDelegate(Up_Pressed));
            keyPressDict.Add("A", new ProcessKeyDelegate(Left_Pressed));
            keyPressDict.Add("S", new ProcessKeyDelegate(Down_Pressed));
            keyPressDict.Add("D", new ProcessKeyDelegate(Right_Pressed));
            keyReleaseDict.Add("W", new ProcessKeyDelegate(Up_Released));
            keyReleaseDict.Add("A", new ProcessKeyDelegate(Left_Released));
            keyReleaseDict.Add("S", new ProcessKeyDelegate(Down_Released));
            keyReleaseDict.Add("D", new ProcessKeyDelegate(Right_Released));
        }

        //Public Methods
        public void Set_Player(Character newPlayer)
        {
            player = newPlayer;
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
        private void Up_Pressed()
        {
            if (player != null)
                player.Up_Pressed();
        }

        private void Down_Pressed()
        {
            if (player != null)
                player.Down_Pressed();
        }

        private void Left_Pressed()
        {
            if (player != null)
                player.Left_Pressed();
        }

        private void Right_Pressed()
        {
            if (player != null)
                player.Right_Pressed();
        }

        private void Up_Released()
        {
            if (player != null)
                player.Up_Released();
        }

        private void Down_Released()
        {
            if (player != null)
                player.Down_Released();
        }

        private void Left_Released()
        {
            if (player != null)
                player.Left_Released();
        }

        private void Right_Released()
        {
            if (player != null)
                player.Right_Released();
        }
    }
}
