using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel.Result;
using SmartLearningPlanner.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.Application.Services
{
    public class S3MinioService : IS3Service
    {
        private readonly IMinioClient _minioClient;
        public S3MinioService(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public async Task<bool> CreateBucketAsync(string bucketName)
        {
            try
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        public async Task<ListAllMyBucketsResult> GetBucketListAsync()
        {
            return await _minioClient.ListBucketsAsync().ConfigureAwait(false);
        }

        #region NOTREADY
        public Task<FileResult> DownloadAsync(string bucketName, string objectName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetObjectListInBucketAsync(string bucketName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string bucketName, string objectName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadAsync(string bucketName, string objectName, IFormFile formFile)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
