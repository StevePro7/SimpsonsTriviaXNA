using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WindowsGame.Common.Inputs.Types;
using WindowsGame.Common.Interfaces;

namespace WindowsGame.Common.Inputs
{
	public class WorkInputFactory : BaseInputFactory, IInputFactory
	{
		public WorkInputFactory(IJoystickInput joystickInput, IKeyboardInput keyboardInput, IMouseScreenInput mouseScreenInput)
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

		protected override Boolean HoldUp()
		{
			return KeyboardInput.KeyHold(Keys.Up) || JoyHoldUp();
		}

		protected override Boolean HoldDown()
		{
			return KeyboardInput.KeyHold(Keys.Down) || JoyHoldDown();
		}

		protected override Boolean HoldLeft()
		{
			return KeyboardInput.KeyHold(Keys.Left) || JoyHoldLeft();
		}

		protected override Boolean HoldRight()
		{
			return KeyboardInput.KeyHold(Keys.Right) || JoyHoldRight();
		}

		protected override Boolean MoveUp()
		{
			return KeyboardInput.KeyPress(Keys.Up) || JoyMoveUp();
		}

		protected override Boolean MoveDown()
		{
			return KeyboardInput.KeyPress(Keys.Down) || JoyMoveDown();
		}

		protected override Boolean MoveLeft()
		{
			return KeyboardInput.KeyPress(Keys.Left) || JoyMoveLeft();
		}

		protected override Boolean MoveRight()
		{
			return KeyboardInput.KeyPress(Keys.Right) || JoyMoveRight();
		}

		public Boolean Escape()
		{
			return KeyboardInput.KeyHold(Keys.Escape) || JoyEscape();
		}
		public Boolean Pause()
		{
			return KeyboardInput.KeyHold(Keys.Escape) || JoyHold(Buttons.Start) || MouseDetect(PauseLeft, PauseRight);
		}
		public Boolean Next()
		{
			return KeyboardInput.KeyHold(Keys.Enter) || JoyHold(Buttons.A) || MouseScreenInput.ButtonHold();
		}
		public Boolean Board()
		{
			return KeyboardInput.KeyHold(Keys.Enter) || JoyHold(Buttons.A) || MouseDetect(ArrowsLeft, PopupRight);
		}
		public Boolean Released()
		{
			return false;
		}
		public Boolean Space()
		{
			return KeyboardInput.KeyPress(Keys.Space);
		}

		private Boolean MouseDetect(UInt16 lhs, UInt16 rhs)
		{
			if (!MouseScreenInput.ButtonHold())
			{
				return false;
			}

			return MouseScreenInput.CurrMouseX > lhs && MouseScreenInput.CurrMouseX < rhs;
		}

	}
}