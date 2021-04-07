using Amazon.S3;
using Amazon.S3.Model;
using Pitako.Domain.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Pitako.Api.Services
{
    public class AWSS3Service : IAWSS3Service
    {
        public string BucketName => "pitako";
        private static String _accessKey = "AKIA5CBOAD7AJTC7G4UQ";

        private static String _accessSecret = "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";


        public async Task<string> PutImgAsync(string base64, string path, string id)
        {
            string ret = "ERRO: Carregando imagem...";

            try
            {
                base64 = base64.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "");
                byte[] bytes = Convert.FromBase64String(base64);

                var region = Amazon.RegionEndpoint.SAEast1;

                using (var client = new AmazonS3Client(_accessKey, _accessSecret, region))
                {
                    PutObjectRequest request = new PutObjectRequest();
                    request.BucketName = BucketName;
                    request.CannedACL = S3CannedACL.PublicRead;
                    request.Key = path + id + ".jpg";
                    request.InputStream = new MemoryStream(bytes);
                    PutObjectResponse response = await client.PutObjectAsync(request);
                    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ret = "https://s3-" + region.SystemName + ".amazonaws.com/" + BucketName + "/" + path + HttpUtility.UrlEncode(id) + ".jpg" + "?Time=" + HttpUtility.UrlEncode(DateTime.Now.ToString());
                    }
                    else
                    {
                        ret = "ERRO: Não foi possível fazer upload da imagem, code error " + response.HttpStatusCode + ", contate o suporte.";
                    }
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                ret = "ERRO: " + amazonS3Exception.Message;
            }
            return ret;
        }
        public async Task<string> DeleteImgAsync(string path, string id)
        {
            string ret = "ERRO: Excluindo imagem...";

            try
            {
                var region = Amazon.RegionEndpoint.SAEast1;
                DeleteObjectRequest deleteObjectRequest =
                new DeleteObjectRequest
                {
                    BucketName = BucketName,
                    Key = path + id + ".jpg"
                };

                using (var client = new AmazonS3Client(_accessKey, _accessSecret, region))
                {
                    await client.DeleteObjectAsync(deleteObjectRequest);
                    ret = "OK";
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                ret = "ERRO: " + amazonS3Exception.Message;

            }
            return ret;
        }
    }
}