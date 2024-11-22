using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class FileController: ControllerBase {

    [HttpGet("/api/file/get")]
    public IActionResult GetFile(string path)
    {
        string filePath = $"./{path}";

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File not found");
        }

        var fileStream = System.IO.File.OpenRead(filePath);

        HttpContext.Response.Headers.Add("Accept-Ranges", "bytes");

        return File(fileStream, "audio/mpeg", Path.GetFileName(filePath));
    }

}