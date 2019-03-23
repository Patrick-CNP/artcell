using Ipfs.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace TestIpfs
{
    class Program
    {
        static void Main(string[] args)
        {
			//string[] files = Directory.GetFiles(Environment.CurrentDirectory,".file", SearchOption.AllDirectories);
			string sourceFilePath = @"d:\artcell\header.png";
			IpfsService service = new IpfsService(@"d:\artcell\tools\go-ipfs\ipfs.exe");
			

			var hash = service.AddFileToStorage(sourceFilePath);
			var filePath = service.GetFileFromStorage(hash);
			FileHepler.ChangeFileExtension(filePath);
			
			if (File.Exists(filePath))
			{

			}
        }
	}
}
