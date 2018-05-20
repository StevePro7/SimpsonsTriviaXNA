using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using WindowsGame.Common.Inputs.Types;
using WindowsGame.Common.Interfaces;

namespace WindowsGame.Common.Inputs
{
	public class WindowsInputFactory : BaseInputFactory, IInputFactory
	{
		public WindowsInputFactory(IJoystickInput joystickInput, IKeyboardInput keyboardInput, IMouseScreenInput mouseScreenInput)
		{
			JoystickInput = joystickInput;
			KeyboardInput = keyboardInput;
			MouseScreenInput = mouseScreenInput;
		}

		public void Update(GameTime gameTime)
		{
			JoystickInput.Update(gameTime);
			KeyboardInput.Update(gameTime);
			MouseScreenInput.Update(gameTime);
		}

		public Boolean Escape()
		{
			return KeyboardInput.KeyHold(Keys.Escape) || JoyEscape();
		}

		public Boolean Advance()
		{
			return MouseScreenInput.ButtonHold();
		}

		public Boolean LeftArrow()
		{
			if (!MouseScreenInput.ButtonHold())
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.LeftArrow(MouseScreenInput.CurrMouseX, MouseScreenInput.CurrMouseY);
		}

		public Boolean RghtArrow()
		{
			if (!MouseScreenInput.ButtonHold())
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.RghtArrow(MouseScreenInput.CurrMouseX, MouseScreenInput.CurrMouseY);
		}

		public Boolean VolumeIcon()
		{
			if (!MouseScreenInput.ButtonHold())
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.VolumeIcon(MouseScreenInput.CurrMouseX, MouseScreenInput.CurrMouseY);
		}

	}
}