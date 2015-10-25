using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RemoteFileJsn {
    public class RemoteFile {
        public string FileName { get; set; }
        public string FullName { get; set; }
        public string MD5 { get; set; }
        public string Url { get; set; }
        public long Size { get; set; }
        public string Status { get; set; }
    }
}
