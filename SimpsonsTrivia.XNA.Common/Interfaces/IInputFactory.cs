using System;
using Microsoft.Xna.Framework;

namespace WindowsGame.Common.Interfaces
{
	public interface IInputFactory
	{
		void Initialize();
		void Update(GameTime gameTime);

		Boolean Escape();
		Boolean Pause();
		Boolean Next();
		Boolean Board();
		Boolean Sides();
		Boolean Released();
		Boolean Space();

		void SetMotors(Single leftMotor, Single rightMotor);
		void ResetMotors();
	}
}