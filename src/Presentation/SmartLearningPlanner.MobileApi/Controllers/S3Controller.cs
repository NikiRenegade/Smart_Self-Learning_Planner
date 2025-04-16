using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.Args;
using Minio.DataModel.Result;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3Controller : ControllerBase
    {
        private readonly IS3Service _s3Service;

        public S3Controller(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpGet("buckets")]
        public async Task<ListAllMyBucketsResult> GetBucketList()
        {
            return await _s3Service.GetBucketListAsync();
        }

        [HttpPost("buckets/create")]
        public async Task<bool> Create(string bucketName)
        {
            return await _s3Service.CreateBucketAsync(bucketName);
        }
    }
}
