using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Windows.Forms;

namespace FileServer {
    public class FileHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.RequestUri.AbsolutePath.StartsWith("/api/", StringComparison.OrdinalIgnoreCase))
                return base.SendAsync(request, cancellationToken);
            return Task<HttpResponseMessage>.Factory.StartNew(() => {
                var response = request.CreateResponse();
                var baseFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var suffix = request.RequestUri.AbsolutePath == "/" ? "test.html" : request.RequestUri.AbsolutePath.Substring(1);
                var fullPath = Path.Combine(baseFolder, suffix);
                if (!File.Exists(fullPath)) return response;

                response.Content =
                    //new StringContent(File.ReadAllText(fullPath), Encoding.UTF8,"text/html");
                    new StreamContent(new FileStream(fullPath, FileMode.Open));
                //new ByteArrayContent(File.ReadAllBytes(fullPath));
                response.Content.Headers.ContentType = GetMediaType(fullPath);
                return response;
            });
        }

        MediaTypeHeaderValue GetMediaType(string filph) {
            var ext = Path.GetExtension(filph).ToLower();
            switch (ext) {
                case ".css":
                case ".js":
                    return new MediaTypeHeaderValue(MediaTypeNames.Text.Plain);
                case ".jpeg":
                case ".jpg":
                    return new MediaTypeHeaderValue(MediaTypeNames.Image.Jpeg);
                case ".gif":
                    return new MediaTypeHeaderValue(MediaTypeNames.Image.Gif);
                case ".png":
                    return new MediaTypeHeaderValue("image/png");
                case ".bmp":
                    return new MediaTypeHeaderValue("image/bmp");
                case ".html":
                case ".htm":
                case ".xhtml":
                case ".chtml":
                case ".shtml":
                    return new MediaTypeHeaderValue(MediaTypeNames.Text.Html);
                default:
                    return new MediaTypeHeaderValue(MediaTypeNames.Text.Html);
            }
        }
    }

    public class WebFormatter : System.Net.Http.Formatting.MediaTypeFormatter {
        public WebFormatter() {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
        }

        public override bool CanReadType(Type type) {
            return false;
        }

        public override bool CanWriteType(Type type) {
            return true;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext) {
            var viewmodel = value as string;
            var sr = new StreamWriter(writeStream);
            sr.Write(viewmodel);
            sr.Flush();
            var tcs = new TaskCompletionSource<Stream>();
            tcs.SetResult(writeStream);
            return tcs.Task;
        }
    }

    public class WebController : ApiController {
        public async Task<HttpResponseMessage> Post() {
            if (!Request.Content.IsMimeMultipartContent()) {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var svrpath = Path.Combine(Application.StartupPath, "UpdateFiles");
            if (!Directory.Exists(svrpath)) {
                Directory.CreateDirectory(svrpath);
            }
            var provider = new CustomMultipartFormDataStreamProvider(svrpath);

            try {
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData) {
                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    var svrfilepath = Path.Combine(svrpath, provider.FormData.GetValues("ServerDir")[0], fileinfo.Name);
                    var svrdir= Path.Combine(svrpath, provider.FormData.GetValues("ServerDir")[0]);
                    if (!Directory.Exists(svrdir)) {
                        Directory.CreateDirectory(svrdir);
                    }
                    fileinfo.CopyTo(svrfilepath, true);
                    fileinfo.Delete(); 

                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            } catch (System.Exception e) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        // We implement MultipartFormDataStreamProvider to override the filename of File which  
        // will be stored on server, or else the default name will be of the format like Body-  
        // Part_{GUID}. In the following implementation we simply get the FileName from   
        // ContentDisposition Header of the Request Body.  
        public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider {
            public CustomMultipartFormDataStreamProvider(string path) : base(path) { }
            public override string GetLocalFileName(HttpContentHeaders headers) {
                return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            }

        }  


        string GetFileContent(string fi) {
            return File.ReadAllText(fi);
        }

        public HttpResponseMessage Get(string fileName = null) {
            var wwwRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(wwwRoot, fileName);
            if (File.Exists(filePath)) {
                if ((filePath).EndsWith(".txt", StringComparison.OrdinalIgnoreCase)) {
                    return this.Request.CreateResponse(
                       HttpStatusCode.OK,
                       GetFileContent(filePath),
                       "application/json");
                }

                if ((filePath).EndsWith(".dll", StringComparison.OrdinalIgnoreCase)) {
                    return this.Request.CreateResponse(
                       HttpStatusCode.OK,
                       GetFileContent(filePath),
                       "application/json");
                }


                if ((filePath).EndsWith(".css", StringComparison.OrdinalIgnoreCase)) {
                    return this.Request.CreateResponse(
                       HttpStatusCode.OK,
                       GetFileContent(filePath),
                       "text/css");
                }

                if ((filePath).EndsWith(".js", StringComparison.OrdinalIgnoreCase)) {
                    return this.Request.CreateResponse(
                       HttpStatusCode.OK,
                       GetFileContent(filePath),
                       "application/javascript");
                }

                return this.Request.CreateResponse(
                  HttpStatusCode.OK,
                  GetFileContent(filePath),
                  new WebFormatter());
            }

            return this.Request.CreateResponse(
                HttpStatusCode.NotFound,
                this.GetFileContent(Path.Combine(wwwRoot, "404.html")),
                "text/html");
        }
    }

    public class Token {
        public Token(string userId, string fromIP) {
            UserId = userId;
            IP = fromIP;
        }

        public string UserId { get; private set; }
        public string IP { get; private set; }

        public string Encrypt() {
            return AES.Encrypt(this.ToString());
        }

        public override string ToString() {
            return String.Format("UserId={0};IP={1}", this.UserId, this.IP);
        }

        public static Token Decrypt(string encryptedToken) {
            var de = AES.Decrypt(encryptedToken);
            Dictionary<string, string> dictionary = de.ToDictionary();
            return new Token(dictionary["UserId"], dictionary["IP"]);
        }
    }

    public class TokenInspector : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.RequestUri.AbsolutePath.StartsWith("/api/login", StringComparison.OrdinalIgnoreCase) ||
                request.RequestUri.AbsolutePath.StartsWith("/api/test", StringComparison.OrdinalIgnoreCase)) {
                return base.SendAsync(request, cancellationToken);
            }

            const string TOKEN_NAME = "X-KY-Token";

            if (request.Headers.Contains(TOKEN_NAME)) {
                string encryptedToken = request.Headers.GetValues(TOKEN_NAME).First();
                try {
                    //Token token = Token.Decrypt(encryptedToken);
                    var tks = AES.Decrypt(encryptedToken);
                    Dictionary<string, string> dictionary = tks.ToDictionary();
                    var uid = dictionary["UsrId"]; var ip = dictionary["IP"];

                    HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid indentity or client machine.");
                    //return Task.FromResult(reply);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(reply);
                    return tsc.Task;
                } catch (Exception ex) {
#if !DEBUG
                    HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                    //return Task.FromResult(reply);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(reply);
                    return tsc.Task;
#else
                    throw;
#endif
                }
            } else {
                HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Request is missing authorization token.");
                //return Task.FromResult(reply);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(reply);
                return tsc.Task;
            }
        }

    }
}
