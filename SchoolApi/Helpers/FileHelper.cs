using SchoolApi.Helpers.Interface;

namespace SchoolApi.Helpers
{
    public class FileHelper:IFileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file, string folderName)
        {
            var rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", folderName);
            if (!Directory.Exists(rootPath)) { Directory.CreateDirectory(rootPath); }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(rootPath, fileName);
            using var fileStream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fileName;
        }
    }
}
