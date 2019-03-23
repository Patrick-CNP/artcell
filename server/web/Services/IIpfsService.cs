using System.IO;

namespace web.Services
{
	public interface IIpfsService
    {
		string AddFileToStorage(Stream stream);
		string AddFileToStorage(string filePath);
		string GetFileFromStorage(string hash);
	}
}
