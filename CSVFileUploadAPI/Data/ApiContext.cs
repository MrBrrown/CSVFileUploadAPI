using System;
using CSVFileUploadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CSVFileUploadAPI.Data
{
	public class ApiContext : DbContext
	{
		public DbSet<FileData> fileDatas { get; set; }

		public ApiContext(DbContextOptions<ApiContext> options)
			: base(options) { }
	}
}

