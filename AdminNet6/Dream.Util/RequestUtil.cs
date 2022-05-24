using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dream.Util
{
    public class RequestUtil
    {
        protected class RequestTimer : Timer
        {
            public HttpWebRequest mRequest;
            public RequestTimer(double interval, HttpWebRequest request) : base(interval)
            {

                mRequest = request;
            }
        }
        static void connectionTimeoutCallback(object sender, System.Timers.ElapsedEventArgs e)
        {

            RequestTimer timer = (RequestTimer)sender;
            timer.Enabled = false;

            timer.mRequest.Abort();
        }
        public static string HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc, int connectionTimeout, int responseTimeout)
        {
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            WebResponse wresp = null;
            var wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Timeout = responseTimeout;
            try
            {

                RequestTimer timer = new RequestTimer(connectionTimeout, wr);
                timer.Elapsed += connectionTimeoutCallback;
                timer.Enabled = true;

                //Trust all certificates
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    ((sender, certificate, chain, sslPolicyErrors) => true);

                var rs = wr.GetRequestStream();
                timer.Enabled = false;

                const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\nContent-Type: application/json\r\n\r\n{1}";
                foreach (string key in nvc.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    var formitem = string.Format(formdataTemplate, key, nvc[key]);
                    byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
                rs.Write(boundarybytes, 0, boundarybytes.Length);

                const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                var header = string.Format(headerTemplate, paramName, file, contentType);
                var headerbytes = Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                var buffer = new byte[4096];
                var bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                var trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();



                wresp = wr.GetResponse();
                var stream2 = wresp.GetResponseStream();
                var reader2 = new StreamReader(stream2);
                return reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                throw ex;
            }
            finally
            {
                wr = null;
            }
        }

        public static async Task<string> DoRequestWithBytesPostDataAsync(string requestUri, string method,
                                       string contentType,
                                       int connectionTimeout,
                                       int responseTimeout,
                                       byte[] postData,
                                       CookieContainer cookieContainer = null,
                                       string userAgent = null, string acceptHeaderString = null,
                                       string referer = null
                                       )
        {

            var result = "";
            if (!string.IsNullOrEmpty(requestUri))
            {
                var request = WebRequest.Create(requestUri) as HttpWebRequest;
                if (request != null)
                {
                    var cachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                    request.CachePolicy = cachePolicy;
                    request.Expect = null;
                    if (!string.IsNullOrEmpty(method))
                        request.Method = method;
                    if (!string.IsNullOrEmpty(acceptHeaderString))
                        request.Accept = acceptHeaderString;
                    if (!string.IsNullOrEmpty(referer))
                        request.Referer = referer;
                    if (!string.IsNullOrEmpty(contentType))
                        request.ContentType = contentType;
                    if (!string.IsNullOrEmpty(userAgent))
                        request.UserAgent = userAgent;
                    if (cookieContainer != null)
                        request.CookieContainer = cookieContainer;
                   // request.Headers.Add("pcssecurity", Dream.Security.Provider.Encrypt(Provider.PCSKEY));
                    request.Timeout = responseTimeout;

                    if (request.Method.ToUpper() == "POST")
                    {
                        if (postData != null)
                        {
                            // The connection timeout

                            Timer timer = new Timer(connectionTimeout);
                            timer.Elapsed += (sender, e) =>
                            {
                                Timer thisTimer = (Timer)sender;
                                thisTimer.Enabled = false;
                                request.Abort();
                            };
                            timer.Enabled = true;

                            //Trust all certificates
                            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                                ((sender, certificate, chain, sslPolicyErrors) => true);

                            request.ContentLength = postData.Length;
                            using (var dataStream = request.GetRequestStream())
                            {
                                timer.Enabled = false;
                                dataStream.Write(postData, 0, postData.Length);
                            }
                        }
                    }

                    using (var httpWebResponse = request.GetResponse() as HttpWebResponse)
                    {
                        if (httpWebResponse != null)
                        {
                            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                            {
                                result = await streamReader.ReadToEndAsync();
                            }
                            return result;
                        }
                    }
                }
            }
            return "";
        }

    }
}
