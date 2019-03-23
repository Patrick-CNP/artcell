using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestIpfs
{
    public interface IIpfsService
    {
		string AddFileToStorage(Stream stream);
		string AddFileToStorage(string filePath);
		string GetFileFromStorage(string hash);
    }
}
