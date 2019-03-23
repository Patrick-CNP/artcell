using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestIpfs
{
    public class FileHepler
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
