﻿using System;
using Microsoft.Xna.Framework.Input;
using WindowsGame.Common.Inputs.Types;

namespace WindowsGame.Common.Inputs
{
	public abstract class BaseInputFactory
	{
		protected UInt16 ArrowsLeft, ArrowsRight, PopupLeft, PopupRight, PauseLeft, PauseRight;
		protected UInt16 Distance, MenuUp, MenuDown, MenuTop, MenuBottom;

		protected virtual Boolean HoldUp() { return false; }
		protected virtual Boolean HoldDown() { return false; }
		protected virtual Boolean HoldLeft() { return false; }
		protected virtual Boolean HoldRight() { return false; }

		protected virtual Boolean MoveUp() { return false; }
		protected virtual Boolean MoveDown() { return false; }
		protected virtual Boolean MoveLeft() { return false; }
		protected virtual Boolean MoveRight() { return false; }

		protected IJoystickInput JoystickInput;
		protected IKeyboardInput KeyboardInput;
		protected IMouseScreenInput MouseScreenInput;
		protected ITouchScreenInput TouchScreenInput;

		public virtual void Initialize()
		{
		}

		public virtual Boolean Sides()
		{
			return false;
		}
		protected Boolean JoyHold(Buttons button)
		{
			return JoystickInput.JoyHold(button);
		}
		protected Boolean JoyMove(Buttons button)
		{
			return JoystickInput.JoyMove(button);
		}
		protected Boolean JoyEscape()
		{
			return JoystickInput.JoyHold(Buttons.B) || JoystickInput.JoyHold(Buttons.Back);
		}

		public virtual void SetMotors(Single leftMotor, Single rightMotor)
		{
			JoystickInput.SetMotors(leftMotor, rightMotor);
		}
		public virtual void ResetMotors()
		{
			JoystickInput.ResetMotors();
		}

		protected Boolean JoyMoveUp()
		{
			return JoyMove(Buttons.DPadUp);
		}
		protected Boolean JoyMoveDown()
		{
			return JoyMove(Buttons.DPadDown);
		}
		protected Boolean JoyMoveLeft()
		{
			return JoyMove(Buttons.DPadLeft);
		}
		protected Boolean JoyMoveRight()
		{
			return JoyMove(Buttons.DPadRight);
		}

		protected Boolean JoyHoldUp()
		{
			return JoyHold(Buttons.DPadUp);
		}
		protected Boolean JoyHoldDown()
		{
			return JoyHold(Buttons.DPadDown);
		}
		protected Boolean JoyHoldLeft()
		{
			return JoyHold(Buttons.DPadLeft);
		}
		protected Boolean JoyHoldRight()
		{
			return JoyHold(Buttons.DPadRight);
		}

	}
}