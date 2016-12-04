using _7.File_Upload.Migrations;
using _7.File_Upload.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _7.File_Upload.Data
{
    public class FileUploadDbContext : DbContext
    {
        public FileUploadDbContext()
            : base("name=FileUploadDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FileUploadDbContext, Configuration>());
        }

        public virtual IDbSet<File> Files { get; set; }
    }
}