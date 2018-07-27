# aws-sdk-net-1014
Reproduction scenario for https://github.com/aws/aws-sdk-net/issues/1014

How to run:

First, make sure you have installed docker and docker-compose on your host operating system.
In order to run the scenario, navigate to the root of this project and run:
```
docker-compose up
```

This should pull the docker images and launch the process. After launching, you should see output like this:
```
$ docker-compose up
Creating network "aws-sdk-net-1014_default" with the default driver
Creating aws-sdk-net-1014_localstack_1 ... done
Creating aws-sdk-net-1014_dotnet_1     ... done
Attaching to aws-sdk-net-1014_localstack_1, aws-sdk-net-1014_dotnet_1
localstack_1  | 2018-07-27 18:00:40,929 CRIT Supervisor running as root (no user in config file)
localstack_1  | 2018-07-27 18:00:40,932 INFO supervisord started with pid 1
localstack_1  | 2018-07-27 18:00:41,935 INFO spawned: 'dashboard' with pid 8
localstack_1  | 2018-07-27 18:00:41,943 INFO spawned: 'infra' with pid 9
localstack_1  | (. .venv/bin/activate; bin/localstack web)
localstack_1  | (. .venv/bin/activate; exec bin/localstack start)
localstack_1  | Starting local dev environment. CTRL-C to quit.
localstack_1  | 2018-07-27 18:00:43,015 INFO success: dashboard entered RUNNING state, process has stayed up for > than 1 seconds (startsecs)
localstack_1  | 2018-07-27 18:00:43,015 INFO success: infra entered RUNNING state, process has stayed up for > than 1 seconds (startsecs)
localstack_1  | 2018-07-27T18:00:43:INFO:werkzeug:  * Running on http://0.0.0.0:8080/ (Press CTRL+C to quit)
localstack_1  | 2018-07-27T18:00:43:INFO:werkzeug:  * Restarting with stat
localstack_1  | 2018-07-27T18:00:43:WARNING:werkzeug:  * Debugger is active!
localstack_1  | 2018-07-27T18:00:43:INFO:werkzeug:  * Debugger PIN: 236-241-381
localstack_1  | Starting mock DynamoDB (http port 4569)...
localstack_1  | Starting mock S3 (http port 4572)...
localstack_1  | Ready.
dotnet_1      |
dotnet_1      | Unhandled Exception: System.AggregateException: One or more errors occurred. (No such device or address) ---> System.Net.Http.HttpRequestException: No such device or address ---> System.Net.Sockets.SocketException: No such device or address
dotnet_1      |    at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
dotnet_1      |    --- End of inner exception stack trace ---
dotnet_1      |    at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
dotnet_1      |    at System.Threading.Tasks.ValueTask`1.get_Result()
dotnet_1      |    at System.Net.Http.HttpConnectionPool.CreateConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
dotnet_1      |    at System.Threading.Tasks.ValueTask`1.get_Result()
dotnet_1      |    at System.Net.Http.HttpConnectionPool.WaitForCreatedConnectionAsync(ValueTask`1 creationTask)
dotnet_1      |    at System.Threading.Tasks.ValueTask`1.get_Result()
dotnet_1      |    at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
dotnet_1      |    at System.Net.Http.HttpClient.FinishSendAsyncUnbuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
dotnet_1      |    at Amazon.Runtime.HttpWebRequestMessage.GetResponseAsync(CancellationToken cancellationToken) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\HttpHandler\_mobile\HttpRequestMessageFactory.cs:line 428
dotnet_1      |    at Amazon.Runtime.Internal.HttpHandler`1.InvokeAsync[T](IExecutionContext executionContext) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\HttpHandler\HttpHandler.cs:line 175
dotnet_1      |    at Amazon.Runtime.Internal.RedirectHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.Unmarshaller.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.S3.Internal.AmazonS3ResponseHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.ErrorHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.CredentialsRetriever.InvokeAsync[T](IExecutionContext executionContext) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\Handlers\CredentialsRetriever.cs:line 98
dotnet_1      |    at Amazon.Runtime.Internal.RetryHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.RetryHandler.InvokeAsync[T](IExecutionContext executionContext) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\RetryHandler\RetryHandler.cs:line 137
dotnet_1      |    at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.S3.Internal.AmazonS3ExceptionHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.ErrorCallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    at Amazon.Runtime.Internal.MetricsHandler.InvokeAsync[T](IExecutionContext executionContext)
dotnet_1      |    --- End of inner exception stack trace ---
dotnet_1      |    at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
dotnet_1      |    at System.Threading.Tasks.Task.Wait()
dotnet_1      |    at TestS3Client2.Program.TestS3() in /TestS3Client2/Program.cs:line 68
dotnet_1      |    at TestS3Client2.Program.Main(String[] args) in /TestS3Client2/Program.cs:line 15
aws-sdk-net-1014_dotnet_1 exited with code 134
```

The expected behavior here is that the newly created bucket name will be printed out, but this exception is thrown instead.

If you change Program.cs to test out the AmazonDynamoDBClient as follows:
```
        static void Main(string[] args)
        {
            // TestS3();
            TestDynamoDB();
        }
```

You should see the following output as the process runs successfully, and the newly created table name is printed out:
```
$ docker-compose up
Starting aws-sdk-net-1014_localstack_1 ... done
Starting aws-sdk-net-1014_dotnet_1     ... done
Attaching to aws-sdk-net-1014_localstack_1, aws-sdk-net-1014_dotnet_1
localstack_1  | 2018-07-27 18:11:21,059 CRIT Supervisor running as root (no user in config file)
localstack_1  | 2018-07-27 18:11:21,061 INFO supervisord started with pid 1
localstack_1  | 2018-07-27 18:11:22,066 INFO spawned: 'dashboard' with pid 11
localstack_1  | 2018-07-27 18:11:22,069 INFO spawned: 'infra' with pid 12
localstack_1  | (. .venv/bin/activate; bin/localstack web)
localstack_1  | (. .venv/bin/activate; exec bin/localstack start)
localstack_1  | 2018-07-27T18:11:22:INFO:werkzeug:  * Running on http://0.0.0.0:8080/ (Press CTRL+C to quit)
localstack_1  | 2018-07-27T18:11:22:INFO:werkzeug:  * Restarting with stat
localstack_1  | Starting local dev environment. CTRL-C to quit.
localstack_1  | 2018-07-27 18:11:23,251 INFO success: dashboard entered RUNNING state, process has stayed up for > than 1 seconds (startsecs)
localstack_1  | 2018-07-27 18:11:23,252 INFO success: infra entered RUNNING state, process has stayed up for > than 1 seconds (startsecs)
localstack_1  | 2018-07-27T18:11:23:WARNING:werkzeug:  * Debugger is active!
localstack_1  | 2018-07-27T18:11:23:INFO:werkzeug:  * Debugger PIN: 236-241-381
localstack_1  | Starting mock DynamoDB (http port 4569)...
localstack_1  | Starting mock S3 (http port 4572)...
localstack_1  | Ready.
dotnet_1      | Tables:
dotnet_1      |  - testtable
aws-sdk-net-1014_dotnet_1 exited with code 0
```
