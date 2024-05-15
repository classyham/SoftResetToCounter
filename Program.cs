using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;


namespace SoftReset
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize InputSimulator
            var inputSimulator = new InputSimulator();

            // Initialize XInput
            var controller = new Controller(UserIndex.One); // Adjust the UserIndex if needed

            // Variable to track the previous button state
            bool previousState = false;

            // Main loop to continuously check for gamepad input
            Console.WriteLine("Press A + B + Start + Back on your gamepad to trigger counter.");
            while (true)
            {
                // Get the state of the gamepad
                var state = controller.GetState().Gamepad.Buttons;

                // Check if the A, B, Start, and Back buttons are pressed
                bool currentState = state.HasFlag(GamepadButtonFlags.A) &&
                                    state.HasFlag(GamepadButtonFlags.B) &&
                                    state.HasFlag(GamepadButtonFlags.Start) &&
                                    state.HasFlag(GamepadButtonFlags.Back);

                // If the buttons are pressed and were not pressed in the previous state
                if (currentState && !previousState)
                {
                    //Console.WriteLine("Pressed");
                    // Simulate pressing Control and Equals keys
                    inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.CONTROL, WindowsInput.Native.VirtualKeyCode.OEM_PLUS);
                }

                // Update previous state
                previousState = currentState;

                // Sleep for a short duration to avoid high CPU usage
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
