
using System;
namespace WindowsGame.Common.Managers
{
	public interface IInputManager
	{
		void Initialize();
		Boolean Next();
	}

	public class InputManager : IInputManager
	{
		public void Initialize()
		{
		}

		Boolean IInputManager.Next()
		{
			return false;
		}

	}
}