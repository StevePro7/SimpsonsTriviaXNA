using System;

namespace WindowsGame.Common.Managers
{
	public interface ITextManager
	{
		void Initialize();
		void Initialize(String root);
		void InitializeBuild();
		void LoadContent();
	}

	public class TextManager : ITextManager
	{
		public void Initialize()
		{
		}

		public void Initialize(string root)
		{
		}

		public void InitializeBuild()
		{
		}

		public void LoadContent()
		{
		}

	}
}