
using System;
using Microsoft.Xna.Framework;
namespace WindowsGame.Common.Managers
{
	public interface IInputManager
	{
		void Initialize();
		void Update(GameTime gameTime);

		Boolean Next();
	}

	public class InputManager : IInputManager
	{
		public void Initialize()
		{
		}

		public void Update(GameTime gameTime)
		{
			//inputFactory.Update(gameTime);
		}

		Boolean IInputManager.Next()
		{
			return false;
		}

	}
}