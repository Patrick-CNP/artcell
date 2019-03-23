using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace web.Helpers
{
    public class FileHelper
    {
		public static void ChangeFileExtension(string filePath)
		{
			var destFilePath = Path.ChangeExtension(filePath, ".jpg");
			if (!File.Exists(destFilePath))
			{
				File.Move(filePath, destFilePath);
			}
		}
	}
}
