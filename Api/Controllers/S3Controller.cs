using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace S3FileOperations.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3Controller : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;

        public S3Controller(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var request = new PutObjectRequest()
            {
                BucketName = "blazor-file-transfer-demo",
                Key = file.FileName,
                InputStream = file.OpenReadStream()
            };

            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            return Ok($"File {file.FileName} uploaded to S3 successfully!");
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFileAsync(string key)
        {
            var s3Object = await _s3Client.GetObjectAsync("blazor-file-transfer-demo", key);
            return File(s3Object.ResponseStream, s3Object.Headers.ContentType, key);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilesAsync()
        {
            var request = new ListObjectsV2Request()
            {
                BucketName = "blazor-file-transfer-demo",
            };
            var result = await _s3Client.ListObjectsV2Async(request);
            return Ok(result.S3Objects);
        }
    }
}
