using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using WindowsGame.Common.Inputs.Types;
using WindowsGame.Common.Interfaces;

namespace WindowsGame.Common.Inputs
{
	public class FoneInputFactory : BaseInputFactory, IInputFactory
	{
		public FoneInputFactory(IJoystickInput joystickInput, ITouchScreenInput touchScreenInput)
		{
			JoystickInput = joystickInput;
			TouchScreenInput = touchScreenInput;
		}

		public override void Initialize()
		{
			TouchScreenInput.Initialize();
			base.Initialize();
		}
		
		public void Update(GameTime gameTime)
		{
			JoystickInput.Update(gameTime);
			TouchScreenInput.Update(gameTime);
		}

		public Boolean Escape()
		{
			return JoystickInput.JoyMove(Buttons.Back);
		}
		public Boolean Pause()
		{
			Boolean pause = JoystickInput.JoyMove(Buttons.Back);
			if (!pause)
			{
				if (Vector2.Zero == TouchScreenInput.TouchPosition)
				{
					return false;
				}
				if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
				{
					return false;
				}

				pause = TouchScreenInput.TouchPosition.X > PauseLeft && TouchScreenInput.TouchPosition.X < PauseRight;
			}

			return pause;
		}

		public Boolean Next()
		{
			return TouchLocationState.Pressed == TouchScreenInput.TouchState;
		}
		public Boolean Board()
		{
			if (Vector2.Zero == TouchScreenInput.TouchPosition)
			{
				return false;
			}
			if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
			{
				return false;
			}

			return TouchScreenInput.TouchPosition.X > ArrowsLeft && TouchScreenInput.TouchPosition.X < PopupRight;
		}
		public override Boolean Sides()
		{
			if (Vector2.Zero == TouchScreenInput.TouchPosition)
			{
				return false;
			}
			if (TouchLocationState.Pressed != TouchScreenInput.TouchState)
			{
				return false;
			}

			return TouchScreenInput.TouchPosition.X <= ArrowsLeft || TouchScreenInput.TouchPosition.X >= ArrowsRight;
		}

		public Boolean Released()
		{
			return TouchLocationState.Released == TouchScreenInput.TouchState;
		}
		public Boolean Space()
		{
			return false;
		}

		public override void SetMotors(float leftMotor, float rightMotor)
		{
		}
		public override void ResetMotors()
		{
		}

	}
}