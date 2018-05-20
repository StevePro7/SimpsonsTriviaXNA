using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using WindowsGame.Common.Objects;

namespace WindowsGame.Common.Screens
{
	public abstract class BaseScreen
	{
		protected UInt16 Timer { get; set; }
		protected Vector2 BannerPosition { get; set; }
		protected IList<TextData> TextDataList { get; private set; }
		protected IList<Vector2> TextPositions { get; set; }

		public virtual void Initialize()
		{
		}

		public virtual void LoadContent()
		{
			Timer = 0;
		}

		protected void UpdateTimer(GameTime gameTime)
		{
			Timer += (UInt16)gameTime.ElapsedGameTime.Milliseconds;
		}

		public virtual void Draw()
		{
		}

		protected void LoadTextData()
		{
			LoadTextData(GetType().Name);
		}
		protected void LoadTextData(Byte suffix)
		{
			String name = String.Format("{0}{1}", GetType().Name, suffix);
			LoadTextData(name);
		}

		private void LoadTextData(String screen)
		{
			TextDataList = MyGame.Manager.TextManager.LoadTextData(screen);
		}

	}
}