using System;
using System.Collections.Generic;

namespace RogueLike
{
	public class Log
	{
		public Log()
		{
			asciiArt = ("+--------------------------------+\n" +
						"|                                |\n" +
						"|                                |\n" +
						"|                                |\n" +
						"|                                |\n" +
						"|                                |\n" +
						"+--------------------------------+");

			messages = new Queue<string>();
		}

		public void AddMessage(string message)
        {
            if (messages.Count == 5)
            {
				messages.Dequeue();
            }

			messages.Enqueue(message);
        }

		public void Render()
        {
			const int messageX  = 1;
			const int mapHeight = 18;
			const int hudHeight = 3;
			const int logOffset = 1;

			int i = 0;
            foreach (string item in messages)
            {
				Console.SetCursorPosition(messageX, i + mapHeight + hudHeight + logOffset);
				Console.Write(item);
				i++;
			}
        }

		public string AsciiArt
        {
			get { return asciiArt; }
        }

		private string asciiArt;
		private Queue<string> messages;
	}
}