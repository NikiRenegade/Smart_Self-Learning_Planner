using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearningPlanner.Application.Interfaces
{
    public interface IS3Service
    {
        Task<bool> CreateBucketAsync(string bucketName);
        Task<ListAllMyBucketsResult> GetBucketListAsync();
        Task<bool> UploadAsync(string bucketName, string objectName, IFormFile formFile);
        Task<FileResult> DownloadAsync(string bucketName, string objectName);
        Task<bool> RemoveAsync(string bucketName, string objectName);
        Task<IEnumerable<string>> GetObjectListInBucketAsync(string bucketName);
    }
}
