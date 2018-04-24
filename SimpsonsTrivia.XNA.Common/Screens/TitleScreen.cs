using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class TitleScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			return ScreenType.Title;
		}

		public override void Draw()
		{
		}

	}
}