using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using web.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IIpfsService _ipfsService;

		private const string LocalStorage = @"D:/artcell/server/web/LocalFileStorage/";

		public UploadController(IIpfsService ipfsService, IHostingEnvironment hostingEnvironment)
		{
			_ipfsService = ipfsService;
			_hostingEnvironment = hostingEnvironment;
		}
		// GET api/upload
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/upload/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/upload
		[HttpPost]
		public string Post([FromQuery]string userId)
		{
			var asd = HttpContext.Request.Headers;
			var files = HttpContext.Request.Form.Files;
			if (files.Count() != 0)
			{
				var formFile = files[0];
				var fileToUploadInIfps = Path.Combine(LocalStorage, formFile.FileName);
				if (formFile.Length > 0)
				{
					using (var stream = new FileStream(Path.Combine(LocalStorage, formFile.FileName), FileMode.Create))
					{
						formFile.CopyTo(stream);
					}

					var hash = _ipfsService.AddFileToStorage(fileToUploadInIfps);

					//TODO: _neoService.Sent(UserKey,Hash); 

					return hash;
				}
				else
					return Constants.FileIsEmpty;
			}
			else
				return Constants.FileWasNotUploaded;
		}

	}
}
