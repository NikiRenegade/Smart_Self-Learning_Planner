using Minio;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var endpoint = "localhost:9000"; //"play.min.io" // тут много бакетов можно увидеть, только тогда выставить secure = true
        var accessKey = "minioadmin";
        var secretKey = "minioadmin";
        var secure = false;

        // Initialize the client with access credentials.
        IMinioClient minio = new MinioClient()
                                    .WithEndpoint(endpoint)
                                    .WithCredentials(accessKey, secretKey)
                                    .WithSSL(secure)
                                    .Build();
        // Create an async task for listing buckets.
        var getListBucketsTask = await minio.ListBucketsAsync().ConfigureAwait(false);

        // Iterate over the list of buckets.
        foreach (var bucket in getListBucketsTask?.Buckets)
        {
            Console.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
        }
    }
}

