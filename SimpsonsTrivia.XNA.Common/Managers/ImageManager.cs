
using Microsoft.Xna.Framework.Graphics;
using WindowsGame.Common.Library;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Static;
namespace WindowsGame.Common.Managers
{
	public interface IImageManager
	{
		void LoadContent();
		void DrawTitle();
	}

	public class ImageManager : IImageManager
	{
		//private Texture2D titleTexture;

		public void LoadContent()
		{
			//titleTexture = 
		}

		public void DrawTitle()
		{
			Rectangle rect = new Rectangle(0, 0, 480, 640);
			float rotate = MathHelper.ToRadians(270);
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, Vector2.Zero, rect, Color.White, rotate, new Vector2(480, 0), 1.0f, SpriteEffects.None, 1.0f);
		}

	}
}