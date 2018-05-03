﻿using System;
using WindowsGame.Common.Data;
using System.Reflection;
using System.Collections.Generic;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Library;

namespace WindowsGame.Common.Managers
{
	public interface ITextManager
	{
		void Initialize();
		void Initialize(String root);
		void InitializeBuild();
		void InitializeBuild(String assemblyName);
		void LoadContent();
		IList<TextData> LoadTextData(String screen);
		IList<TextData> LoadTextData(String screen, Byte textsSize, UInt32 offsetX, Single fontX, Single modY);
		Vector2 GetTextPosition(SByte x, SByte y);
		Vector2 GetTextPosition(SByte x, SByte y, Byte textsSize, UInt32 offsetX, Single fontX, Single fontY);
		void Draw(IEnumerable<TextData> textDataList);
		String BuildVersion { get; }
	}

	public class TextManager : ITextManager
	{
		private static Char[] DELIM;
		private static Char[] PIPES;

		public void Initialize()
		{
			Initialize(String.Empty);
		}

		public void Initialize(String root)
		{
			DELIM = new[] { ',' };
			PIPES = new[] { '|' };

			BaseData.Initialize(root);
		}

		public void InitializeBuild()
		{
#if !WINDOWS_PHONE
			Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
#else
			Assembly assembly = Assembly.GetCallingAssembly();
#endif
			// Get AssemblyVersion from calling AssemblyInfo.cs
			InitializeBuild(assembly.FullName);
		}
		public void InitializeBuild(String assemblyName)
		{
			BuildVersion = assemblyName.Split('=')[1].Split(',')[0];
			if (BuildVersion.EndsWith(".0"))
			{
				BuildVersion = BuildVersion.Substring(0, BuildVersion.Length - 2);
			}
		}

		public void LoadContent()
		{
		}

		public IList<TextData> LoadTextData(String screen)
		{
			return LoadTextData(screen, Constants.TextsSize, Constants.GameOffsetX, Constants.FontOffsetX, Constants.FontOffsetY);
		}
		public IList<TextData> LoadTextData(String screen, Byte textsSize, UInt32 offsetX, Single fontX, Single fontY)
		{
			String file = GetTextFile(screen + ".txt");
			var lines = MyGame.Manager.FileManager.LoadTxt(file);

			var textDataList = new List<TextData>();
			foreach (string line in lines)
			{
				if (line.StartsWith("--"))
				{
					continue;
				}

				String[] items = line.Split(DELIM);
				SByte x = Convert.ToSByte(items[0]);
				SByte y = Convert.ToSByte(items[1]);
				String message = items[2];

				Vector2 postion = GetTextPosition(x, y, textsSize, offsetX, fontX, fontY);
				TextData item = new TextData(postion, message);

				textDataList.Add(item);
			}

			return textDataList;
		}

		public Vector2 GetTextPosition(SByte x, SByte y)
		{
			return GetTextPosition(x, y, Constants.TextsSize, Constants.GameOffsetX, Constants.FontOffsetX, Constants.FontOffsetY);
		}
		public Vector2 GetTextPosition(SByte x, SByte y, Byte textsSize, UInt32 offsetX, Single fontX, Single fontY)
		{
			return new Vector2(x * textsSize + offsetX + fontX, y * textsSize + fontY);
		}

		public void Draw(IEnumerable<TextData> textDataList)
		{
			foreach (TextData data in textDataList)
			{
				Engine.SpriteBatch.DrawString(Assets.EmulogicFont, data.Text, data.Position, data.Color);
			}
		}

		public String BuildVersion { get; private set; }

		private static String GetTextFile(String textFile)
		{
			return String.Format("{0}{1}/{2}/{3}/{4}", BaseData.BaseRoot, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY, Constants.TEXTS_DIRECTORY, textFile);
		}
	}
}