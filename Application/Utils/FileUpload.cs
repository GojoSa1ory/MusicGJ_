public interface FileUploadIntrerface {
    Task<string> UploadFile(string fileType, IFormFile file);
}

public class FileUploadUtil() : FileUploadIntrerface
{
    public async Task<string> UploadFile(string fileType, IFormFile file)
    {
        
        try
        {
            if (file is null) throw new FileNotFoundException();
            
            var uploadPath = $"./Uploads/{fileType}";
            string fullPath = $"{uploadPath}/{file.FileName}";

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var baseUrl = "http://localhost:5214/api/file/get?path=";
            var relativePath = $"Uploads/{fileType}/{file.FileName}";
            var imageUri = new Uri(baseUrl + relativePath);

            return imageUri.ToString();

        }
        catch (Exception e)
        {
            throw new FailedAddFileException(e.Message);
        }
    }
}