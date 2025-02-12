//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//

/*
 * Do not modify this file. This file is generated from the cognito-sync-2014-06-30.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

using Amazon.CognitoSync.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.CognitoSync.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Response Unmarshaller for ListIdentityPoolUsage operation
    /// </summary>  
    public class ListIdentityPoolUsageResponseUnmarshaller : JsonResponseUnmarshaller, ISimplifiedErrorUnmarshaller 
    {
        /// <summary>
        /// Unmarshaller the response from the service to the response class.
        /// </summary>  
        /// <param name="context"></param>
        /// <returns></returns>
        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
            ListIdentityPoolUsageResponse response = new ListIdentityPoolUsageResponse();

            context.Read();
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
                if (context.TestExpression("Count", targetDepth))
                {
                    var unmarshaller = IntUnmarshaller.Instance;
                    response.Count = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("IdentityPoolUsages", targetDepth))
                {
                    var unmarshaller = new ListUnmarshaller<IdentityPoolUsage, IdentityPoolUsageUnmarshaller>(IdentityPoolUsageUnmarshaller.Instance);
                    response.IdentityPoolUsages = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("MaxResults", targetDepth))
                {
                    var unmarshaller = IntUnmarshaller.Instance;
                    response.MaxResults = unmarshaller.Unmarshall(context);
                    continue;
                }
                if (context.TestExpression("NextToken", targetDepth))
                {
                    var unmarshaller = StringUnmarshaller.Instance;
                    response.NextToken = unmarshaller.Unmarshall(context);
                    continue;
                }
            }

            return response;
        }

        /// <summary>
        /// Unmarshaller error response to exception.
        /// </summary>  
        /// <param name="context"></param>
        /// <param name="innerException"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
            if (errorResponse.Code != null && errorResponse.Code.Equals("InternalError"))
            {
                return new InternalErrorException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals("InvalidParameter"))
            {
                return new InvalidParameterException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals("NotAuthorizedError"))
            {
                return new NotAuthorizedException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            if (errorResponse.Code != null && errorResponse.Code.Equals("TooManyRequests"))
            {
                return new TooManyRequestsException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
            return new AmazonCognitoSyncException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
        }

        public AmazonServiceException UnmarshallException(IWebResponseData response, ErrorResponse errorResponse, Exception innerException)
        {
            if (!string.IsNullOrEmpty(errorResponse.Code) && errorResponse.Code.StartsWith("InternalError", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.IsNullOrEmpty(errorResponse.Message)?GetDefaultErrorMessage<AmazonCognitoSyncException>():errorResponse.Message;
                return new InternalErrorException(message, innerException, ErrorType.Unknown, errorResponse.Code, errorResponse.RequestId, response.StatusCode);
            }
            if (!string.IsNullOrEmpty(errorResponse.Code) && errorResponse.Code.StartsWith("InvalidParameter", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.IsNullOrEmpty(errorResponse.Message)?GetDefaultErrorMessage<AmazonCognitoSyncException>():errorResponse.Message;
                return new InvalidParameterException(message, innerException, ErrorType.Unknown, errorResponse.Code, errorResponse.RequestId, response.StatusCode);
            }
            if (!string.IsNullOrEmpty(errorResponse.Code) && errorResponse.Code.StartsWith("NotAuthorizedError", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.IsNullOrEmpty(errorResponse.Message)?GetDefaultErrorMessage<AmazonCognitoSyncException>():errorResponse.Message;
                return new NotAuthorizedException(message, innerException, ErrorType.Unknown, errorResponse.Code, errorResponse.RequestId, response.StatusCode);
            }
            if (!string.IsNullOrEmpty(errorResponse.Code) && errorResponse.Code.StartsWith("TooManyRequests", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.IsNullOrEmpty(errorResponse.Message)?GetDefaultErrorMessage<AmazonCognitoSyncException>():errorResponse.Message;
                return new TooManyRequestsException(message, innerException, ErrorType.Unknown, errorResponse.Code, errorResponse.RequestId, response.StatusCode);
            }
            return new AmazonCognitoSyncException(GetDefaultErrorMessage<AmazonCognitoSyncException>(), innerException, ErrorType.Unknown, errorResponse.Code, errorResponse.RequestId, response.StatusCode);
        }
        private static ListIdentityPoolUsageResponseUnmarshaller _instance = new ListIdentityPoolUsageResponseUnmarshaller();        

        internal static ListIdentityPoolUsageResponseUnmarshaller GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Gets the singleton.
        /// </summary>  
        public static ListIdentityPoolUsageResponseUnmarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}