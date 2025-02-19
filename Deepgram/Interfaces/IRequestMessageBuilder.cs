﻿using System.Net.Http;
using Deepgram.Models;

namespace Deepgram.Interfaces
{
    public interface IRequestMessageBuilder
    {
        /// <summary>
        /// Creates a Http Request Message for the Api calls
        /// </summary>
        /// <param name="method"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="body"></param>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, string uri, Credentials credentials, object body = null, object queryParameters = null);

        /// <summary>
        /// Create a HttpRequestMessage when a stream is the body source
        /// </summary>
        /// <param name="method"></param>
        /// <param name="uri"></param>
        /// <param name="credentials"></param>
        /// <param name="streamSource"></param>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        HttpRequestMessage CreateStreamHttpRequestMessage(HttpMethod method, string uri, Credentials credentials, StreamSource streamSource, object queryParameters = null);
    }
}
