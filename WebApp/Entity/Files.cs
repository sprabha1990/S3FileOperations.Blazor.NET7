namespace S3FileOperations.Blazor.Entity
{
    public class Files
    {
        public string ETag { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
        public long Size { get; set; } = 0;
    }
}
