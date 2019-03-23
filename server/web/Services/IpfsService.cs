using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace web.Services
{
    public class IpfsService : IIpfsService
    {
		private string _ipfsPath;
		private const string _dataFolder = @"D:\artcell\tools\go-ipfs\data";

		public IpfsService(string ipfsPath)
		{
			_ipfsPath = ipfsPath;
		}
		public string AddFileToStorage(Stream stream)
		{
			return "";
		}

		/// <summary>
		/// Add file to storage
		/// </summary>
		/// <param name="filePath">File path</param>
		/// <returns>Returns hash of file</returns>
		public string AddFileToStorage(string filePath)
		{
			using (var _process = new Process())
			{
				_process.StartInfo.FileName = _ipfsPath;
				_process.StartInfo.Arguments = $"add {filePath}";
				_process.StartInfo.UseShellExecute = false;
				_process.StartInfo.RedirectStandardOutput = true;
				_process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				_process.StartInfo.WorkingDirectory = _dataFolder;
				_process.Start();

				string output = _process.StandardOutput.ReadToEnd();

				var array = output.Split(" ");
				if (array.Length == 3)
				{
					return array[1];
				}

				return String.Empty;
			}
		}

		/// <summary>
		/// Get filePath
		/// </summary>
		/// <param name="hash"></param>
		/// <returns></returns>
		public string GetFileFromStorage(string hash)
		{
			using (var _process = new Process())
			{
				_process.StartInfo.FileName = _ipfsPath;
				_process.StartInfo.Arguments = $"get {hash}";
				_process.StartInfo.UseShellExecute = false;
				_process.StartInfo.RedirectStandardOutput = true;
				_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				_process.StartInfo.WorkingDirectory = _dataFolder;
				_process.Start();

				string output = _process.StandardOutput.ReadToEnd();

				if (output.Contains(hash))
					return Path.Combine(_dataFolder, hash);

				return String.Empty;
			}
		}
	}
}
