/*
 *	Use this code snippet in your app.
 *	If you need more information about configurations or implementing the sample code, visit the AWS docs:
 *	https://aws.amazon.com/developer/language/net/getting-started
 */

// https://aws.amazon.com/es/blogs/modernizing-with-aws/how-to-load-net-configuration-from-aws-secrets-manager/

using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json;

namespace WebApi.Helpers;

//public class AmazonSecretGetter
//{
//    public static async Task GetSecret()
//    {
//        string secretName = "prod";
//        string region = "us-east-1";

//        IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

//        GetSecretValueRequest request = new GetSecretValueRequest
//        {
//            SecretId = secretName,
//            VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
//        };

//        GetSecretValueResponse response;

//        try
//        {
//            response = await client.GetSecretValueAsync(request);
//        }
//        catch (Exception e)
//        {
//            // For a list of the exceptions thrown, see
//            // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
//            throw e;
//        }

//        string secret = response.SecretString;
//    }
//}

//public class AmazonSecretsManagerConfigurationProvider : ConfigurationProvider
//{
//    private readonly string _region;
//    private readonly string _secretName;

//    public AmazonSecretsManagerConfigurationProvider(string region, string secretName)
//    {
//        _region = region;
//        _secretName = secretName;
//    }

//    public override void Load()
//    {
//        var secret = GetSecret();

//        Data = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);
//    }

//    private string GetSecret()
//    {
//        var request = new GetSecretValueRequest
//        {
//            SecretId = _secretName,
//            VersionStage = "AWSCURRENT" // VersionStage defaults to AWSCURRENT if unspecified.
//        };

//        using (var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(_region)))
//        {
//            var response = client.GetSecretValueAsync(request).Result;

//            string secretString;
//            if (response.SecretString != null)
//            {
//                secretString = response.SecretString;
//            }
//            else
//            {
//                var memoryStream = response.SecretBinary;
//                var reader = new StreamReader(memoryStream);
//                secretString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
//            }

//            return secretString;
//        }
//    }
//}
