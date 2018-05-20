using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using WindowsGame.Common.Inputs.Types;
using WindowsGame.Common.Interfaces;

namespace WindowsGame.Common.Inputs
{
	public class MobilesInputFactory : BaseInputFactory, IInputFactory
	{
		public MobilesInputFactory(IJoystickInput joystickInput, ITouchScreenInput touchScreenInput)
		{
			JoystickInput = joystickInput;
			TouchScreenInput = touchScreenInput;
		}

		public override void Initialize()
		{
			TouchScreenInput.Initialize();
		}

		public void Update(GameTime gameTime)
		{
			JoystickInput.Update(gameTime);
			TouchScreenInput.Update(gameTime);
		}

		public Boolean Escape()
		{
			return JoyEscape();
		}

		public Boolean Advance()
		{
			return TouchScreenInput.Tap;
		}

		public Boolean LeftArrow()
		{
			if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.LeftArrow(TouchScreenInput.CurrTouchX, TouchScreenInput.CurrTouchY);
		}

		public Boolean RghtArrow()
		{
			if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.RghtArrow(TouchScreenInput.CurrTouchX, TouchScreenInput.CurrTouchY);
		}

		public Boolean VolumeIcon()
		{
			if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
			{
				return false;
			}

			return MyGame.Manager.CollisionManager.VolumeIcon(TouchScreenInput.CurrTouchX, TouchScreenInput.CurrTouchY);
		}

	}
}