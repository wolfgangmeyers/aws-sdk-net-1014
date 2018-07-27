using System;
using System.Collections.Generic;
using Amazon;
using Amazon.S3;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Net;

namespace TestS3Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestS3();
            // TestDynamoDB();
        }

        private static void TestDynamoDB()
        {
            var client = new AmazonDynamoDBClient("foobar", "foobar", new AmazonDynamoDBConfig{
                RegionEndpoint=RegionEndpoint.USEast1,
                ServiceURL = "http://localstack:4569",
                UseHttp = true,
            });
            var t = client.CreateTableAsync(new CreateTableRequest
            {
                TableName = "testtable",
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName="testkey",
                        KeyType="HASH"
                    }
                },
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName="testkey",
                        AttributeType="S"
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1
                }
            });
            t.Wait();
            var t2 = client.ListTablesAsync();
            t2.Wait();
            Console.WriteLine("Tables:");
            foreach (var table in t2.Result.TableNames)
            {
                Console.WriteLine(" - " + table);
            }
        }

        private static void TestS3()
        {
            var client = new AmazonS3Client("foobar", "foobar", new AmazonS3Config{
                RegionEndpoint=RegionEndpoint.USEast1,
                ServiceURL = "http://localstack:4572",
                UseHttp = true,
            });
            client.PutBucketAsync("testbucket").Wait();
            var t = client.ListBucketsAsync();
            t.Wait();
            Console.WriteLine("Buckets:");
            foreach (var bucket in t.Result.Buckets)
            {
                Console.WriteLine(" - " + bucket.BucketName);
            }
        }
    }
}
