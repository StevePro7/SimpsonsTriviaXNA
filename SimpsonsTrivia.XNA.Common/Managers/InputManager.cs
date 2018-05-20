using System;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;

namespace WindowsGame.Common.Managers
{
	public interface IInputManager
	{
		void Initialize();
		void Update(GameTime gameTime);

		Boolean Escape();
		Boolean Advance();
		Boolean LeftArrow();
		Boolean RghtArrow();
		Boolean VolumeIcon();
	}

	public class InputManager : IInputManager
	{
		private readonly IInputFactory inputFactory;

		public InputManager(IInputFactory inputFactory)
		{
			this.inputFactory = inputFactory;
		}

		public void Initialize()
		{
			inputFactory.Initialize();
		}

		public void Update(GameTime gameTime)
		{
			inputFactory.Update(gameTime);
		}

		public Boolean Escape()
		{
			return inputFactory.Escape();
		}

		public Boolean Advance()
		{
			return inputFactory.Advance();
		}

		public Boolean LeftArrow()
		{
			return inputFactory.LeftArrow();
		}
		public Boolean RghtArrow()
		{
			return inputFactory.RghtArrow();
		}

		public Boolean VolumeIcon()
		{
			return inputFactory.VolumeIcon();
		}

		//public Boolean Pause()
		//{
		//	return inputFactory.Pause();
		//}
		//public Boolean Next()
		//{
		//	return inputFactory.Next();
		//}
		//public Boolean Board()
		//{
		//	return inputFactory.Board();
		//}
		//public Boolean Sides()
		//{
		//	return inputFactory.Sides();
		//}
		//public Boolean Released()
		//{
		//	return inputFactory.Released();
		//}
		//public Boolean Space()
		//{
		//	return inputFactory.Space();
		//}

		//public void SetMotors(Single leftMotor, Single rightMotor)
		//{
		//	inputFactory.SetMotors(leftMotor, rightMotor);
		//}
		//public void ResetMotors()
		//{
		//	inputFactory.ResetMotors();
		//}

	}
}